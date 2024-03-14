namespace PetShopInventory
{
    public class ChickenDetails
    {
        public  void ManageChickenInfo()
        {
            ShopDbContext context = new ShopDbContext();
            List<Chicken> ChickenList = context.Chickens.ToList();

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{"Id".PadRight(5)}|{"Name".PadRight(15)}|{"Price".PadRight(15)}|{"Date".PadRight(15)}|");
            Console.WriteLine("-----------------------------------------------------");

            // Display data using foreach loop
            foreach (var Chicken in ChickenList)
            {
                if (Chicken == null) continue;
                Console.WriteLine($"{Chicken.id.ToString().PadRight(5)}|{Chicken.name.PadRight(15)}|{Chicken.price.ToString().PadRight(15)}|{Chicken.datetime.ToString("dd-MM-yyyy").PadRight(15)}|");
                Console.WriteLine("-----------------------------------------------------");
            }

           

            if (ChickenList.Count >= 0)
            {
                ChickenOperation();
            }
        }
        public void ChickenOperation()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\n Chicken Operations:");
            Console.WriteLine(" 1. Add Chicken");
            Console.WriteLine(" 2. Update Chicken");
            Console.WriteLine(" 3. Delete Chicken");
            Console.WriteLine(" 4. Back to Previous Menu");
            Console.WriteLine(" 5. Back to Main Menu");
            Console.Write(" Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    AddChicken();
                    break;
                case "2":
                    UpdateChicken();
                    break;
                case "3":
                    DeleteChicken();
                    break;
                case "4":
                    PetInventory petInventory = new PetInventory();
                    petInventory.PetDetails();
                    break;
                case "5":
                    PetInventory inventory = new PetInventory();
                    inventory.Inventory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

       public void AddChicken()
        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter Chicken name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Chicken Price: ");
                double price = double.Parse(Console.ReadLine());
                DateTime date = DateTime.Today;
                var chicken = new Chicken { type = "Fish", name = Name, price = price, datetime = date };
                context.Chickens.Add(chicken);
                context.SaveChanges();
                Console.WriteLine(" added successfully.");
                Console.WriteLine();
                ChickenOperation();
            }
        }

        public void UpdateChicken()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Chicken ID to update: ");
                int ChickenId = int.Parse(Console.ReadLine());
                var Chicken = context.Chickens.Find(ChickenId);

                if (Chicken != null && Chicken.type == "Fish")
                {
                    Console.Write("Enter new Chicken name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Chicken Price: ");
                    double newPrice = double.Parse(Console.ReadLine());
                    DateTime newdate = DateTime.Today;
                    Chicken.name = newName;
                    Chicken.price = newPrice;
                    Chicken.datetime = newdate;
                    context.SaveChanges();

                    Console.WriteLine("Chicken updated successfully.");
                    Console.WriteLine();
                    ChickenOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Chicken ID or Chicken type. Update failed.");
                }
            }
        }

        public void DeleteChicken()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Chicken ID to delete: ");
                int ChickenId = int.Parse(Console.ReadLine());

                var Chicken = context.Chickens.Find(ChickenId);

                if (Chicken != null && Chicken.type == "Chicken")
                {
                    context.Chickens.Remove(Chicken);
                    context.SaveChanges();

                    Console.WriteLine("Chicken deleted successfully.");
                    Console.WriteLine();
                    ChickenOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Chicken ID or Chicken type. Deletion failed.");
                }
            }
        }
    }

}

