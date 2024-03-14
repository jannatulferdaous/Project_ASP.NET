namespace PetShopInventory
{
    public class ScheduleDetails
    {

        public void ManageSchedule()
        {
            bool continueManaging = true;

            while (continueManaging)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("=== Manage Feeding Schedule ===");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("  1. View All Schedules");
                Console.WriteLine("  2. Add New Schedule");
                Console.WriteLine("  3. Update Existing Schedule");
                Console.WriteLine("  4. Delete Schedule");
                Console.WriteLine("  5. Back to Main Menu");
                Console.WriteLine("-------------------------------------");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllSchedules();
                        break;
                    case "2":
                        AddNewSchedule();
                        break;
                    case "3":
                        UpdateSchedule();
                        break;
                    case "4":
                        DeleteSchedule();
                        break;
                    case "5":
                        continueManaging = false;
                        PetInventory inventory = new PetInventory();
                        inventory.Inventory();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ViewAllSchedules()
        {
            ShopDbContext context = new ShopDbContext();
            List<Schedule> scheduleList = context.Schedules.ToList();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\t{"Id".PadRight(10)}|{"PetsName".PadRight(15)}|{"mealsPerDay".PadRight(15)}|{"Morning".PadRight(15)}|{"NoonTime".PadRight(15)}|{"Evening".PadRight(15)}|{"FoodType".PadRight(15)}|");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");

            // Display data using foreach loop
            foreach (var schedule in scheduleList)
            {
                if (schedule == null) continue;
                Console.WriteLine($"\t{schedule.id.ToString().PadRight(10)}|{schedule.petsname.PadRight(15)}|{schedule.mealsPerDay.PadRight(15)}|{schedule.morningTime.PadRight(15)}|{schedule.noonTime.PadRight(15)}|{schedule.eveningTime.PadRight(15)}|{schedule.foodItem.PadRight(20)}|");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            //Console.WriteLine("-----------------------------------------------------");
        }

        public void AddNewSchedule()

        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter Pets Name: ");
                string PetName = Console.ReadLine();
                Console.Write("Enter  Meals Per Day: ");
                string meals = Console.ReadLine();
                Console.Write("Enter Morning Schedule: ");
                string morning = Console.ReadLine();
                Console.Write("Enter Noon Schedule: ");
                string noon = Console.ReadLine();
                Console.Write("Enter Evening Schedule: ");
                string evening = Console.ReadLine();
                Console.Write("Enter FoodItem Name: ");
                string food = Console.ReadLine();

                var schedule = new Schedule
                {
                    petsname = PetName,
                    mealsPerDay = meals,
                    morningTime = morning,
                    noonTime = noon,
                    eveningTime = evening,
                    foodItem = food,
                };

                context.Schedules.Add(schedule);
                context.SaveChanges();
                Console.WriteLine("Schedule added successfully!");
                Console.WriteLine();
            }
            ManageSchedule();
        }


        public void UpdateSchedule()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Schedule ID to update: ");
                int Id = int.Parse(Console.ReadLine());
                var schedule = context.Schedules.Find(Id);
                if (schedule != null)
                {
                    Console.Write("Enter Pets Name: ");
                    string PetName = Console.ReadLine();
                    Console.Write("Enter  Meals Per Day: ");
                    string meals = Console.ReadLine();
                    Console.Write("Enter Morning Schedule: ");
                    string morning = Console.ReadLine();
                    Console.Write("Enter Noon Schedule: ");
                    string noon = Console.ReadLine();
                    Console.Write("Enter Evening Schedule: ");
                    string evening = Console.ReadLine();
                    Console.Write("Enter FoodItem Name: ");
                    string food = Console.ReadLine();

                    schedule.petsname = PetName;
                    schedule.mealsPerDay = meals;
                    schedule.morningTime = morning;
                    schedule.noonTime = noon;
                    schedule.eveningTime = evening;
                    schedule.foodItem = food;

                    context.SaveChanges();
                    Console.WriteLine("Schedule updated successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Schedule ID . Update failed.");
                }
            }
            ManageSchedule();
        }

        public void DeleteSchedule()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Schedule ID to delete: ");
                int Id = int.Parse(Console.ReadLine());

                var schedule = context.Schedules.Find(Id);

                if (schedule != null)
                {
                    context.Schedules.Remove(schedule);
                    context.SaveChanges();

                    Console.WriteLine("Schedule deleted successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Fish ID or Fish type. Deletion failed.");
                }
            }
            ManageSchedule();
        }
    }

}
