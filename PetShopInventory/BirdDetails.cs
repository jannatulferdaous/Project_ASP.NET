using System.Configuration;

namespace PetShopInventory
{
    public class BirdDetails
    {
        public  void ManageBirdInfo()
        {
            ShopDbContext context = new ShopDbContext();
            List<Bird> birdList = context.Birds.ToList();

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{"Id".PadRight(5)}|{"Name".PadRight(15)}|{"Price".PadRight(15)}|{"Date".PadRight(15)}|");
            Console.WriteLine("-----------------------------------------------------");

            // Display data using foreach loop
            foreach (var bird in birdList)
            {
                if (bird == null) continue;
                Console.WriteLine($"{bird.id.ToString().PadRight(5)}|{bird.name.PadRight(15)}|{bird.price.ToString().PadRight(15)}|{bird.datetime.ToString("dd-MM-yyyy").PadRight(15)}|");
                Console.WriteLine("-----------------------------------------------------");
            }

             

            if (birdList.Count >= 0)
            {
                BirdOperation();
            }
        }
        public  void BirdOperation()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(" \nBird Operations:");
            Console.WriteLine("  1. Add Bird");
            Console.WriteLine("  2. Update Bird");
            Console.WriteLine("  3. Delete Bird");
            Console.WriteLine("  4. Back to Previous Menu");
            Console.WriteLine("  5. Back to Main Menu");
            Console.Write(" Enter your choice: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    AddBird();
                    break;
                case "2":
                    UpdateBird();
                    break;
                case "3":
                    DeleteBird();
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

        public void AddBird()
        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter Bird name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Bird Price: ");
                double price = double.Parse(Console.ReadLine());
                DateTime date = DateTime.Today;
                var Bird = new Bird { type = "Fish", name = Name, price = price, datetime = date };
                context.Birds.Add(Bird);
                context.SaveChanges();
                Console.WriteLine("Bird added successfully.");
                Console.WriteLine();
                BirdOperation();
            }
        }

        public void UpdateBird()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Bird ID to update: ");
                int BirdId = int.Parse(Console.ReadLine());
                var Bird = context.Birds.Find(BirdId);

                if (Bird != null && Bird.type == "Fish")
                {
                    Console.Write("Enter new Bird name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Bird Price: ");
                    double newPrice = double.Parse(Console.ReadLine());
                    DateTime newdate = DateTime.Today;
                    Bird.name = newName;
                    Bird.price = newPrice;
                    Bird.datetime = newdate;

                    context.SaveChanges();
                    Console.WriteLine("Bird updated successfully.");
                    Console.WriteLine();
                    BirdOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Bird ID or Bird type. Update failed.");
                }
            }
        }

        public void DeleteBird()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Bird ID to delete: ");
                int BirdId = int.Parse(Console.ReadLine());

                var birds = context.Birds.Find(BirdId);

                if (birds != null && birds.type == "Bird")
                {
                    context.Birds.Remove(birds);
                    context.SaveChanges();
                    Console.WriteLine("Bird deleted successfully.");
                    Console.WriteLine();
                    BirdOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Fish ID or Fish type. Deletion failed.");
                }
            }
        }
    }

}

