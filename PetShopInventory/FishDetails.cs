namespace PetShopInventory
{
    public class FishDetails
    {
        public  void ManageFishInfo()
        {
            ShopDbContext context = new ShopDbContext();
            List<Fish> fishList = context.Fish.ToList();

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{"Id".PadRight(5)}|{"Name".PadRight(15)}|{"Price".PadRight(15)}|{"Date".PadRight(15)}|");
            Console.WriteLine("-----------------------------------------------------");

            // Display data using foreach loop
            foreach (var fish in fishList)
            {
                if (fish == null) continue;
                Console.WriteLine($"{fish.id.ToString().PadRight(5)}|{fish.name.PadRight(15)}|{fish.price.ToString().PadRight(15)}|{fish.purchaseDate.ToString("dd-MM-yyyy").PadRight(15)}|");
                Console.WriteLine("-----------------------------------------------------");
            }

           

            if (fishList.Count >= 0)
            {
                FishOperation();
            }

 
        }
        public  void FishOperation()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\n Fish Operations:");
            Console.WriteLine(" 1. Add Fish");
            Console.WriteLine(" 2. Update Fish");
            Console.WriteLine(" 3. Delete Fish");
            Console.WriteLine(" 4. Back to Previous Menu");
            Console.WriteLine(" 5. Back to Main Menu");
            Console.Write(" Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    AddFish();
                    break;
                case "2":
                    UpdateFish();
                    break;
                case "3":
                    DeleteFish();
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

        public void AddFish()
        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter Fish name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Fish Price: ");
                double price = double.Parse(Console.ReadLine());
                DateTime date = DateTime.Today;
                var fish = new Fish { type = "Fish", name = Name, price = price, purchaseDate = date };
                context.Fish.Add(fish); 
                context.SaveChanges();

                Console.WriteLine("Fish added successfully.");
                Console.WriteLine();
                FishOperation();
            }
        }

        public void UpdateFish()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Fish ID to update: ");
                int fishId = int.Parse(Console.ReadLine());
                var fish = context.Fish.Find(fishId);

                if (fish != null && fish.type == "Fish")
                {
                    Console.Write("Enter new Fish name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Fish Price: ");
                    double newPrice = double.Parse(Console.ReadLine());
                    DateTime newdate = DateTime.Today;
                    fish.name = newName;
                    fish.price = newPrice;
                    fish.purchaseDate = newdate;
                    context.SaveChanges();

                    Console.WriteLine("Fish updated successfully.");
                    Console.WriteLine();
                    FishOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Fish ID or Fish type. Update failed.");
                }
            }
        }

        public void DeleteFish()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Fish ID to delete: ");
                int FishId = int.Parse(Console.ReadLine());

                var fish = context.Fish.Find(FishId);

                if (fish != null && fish.type == "Fish")
                {
                    context.Fish.Remove(fish);
                    context.SaveChanges();

                    Console.WriteLine("Fish deleted successfully.");
                    Console.WriteLine();
                    FishOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Fish ID or Fish type. Deletion failed.");
                }
            }
        }
    }

}

