namespace PetShopInventory
{
    public class CatDetails
    {
        public void ManageCatInfo()
        {
            ShopDbContext context = new ShopDbContext();
            List<Cat> catList = context.cats.ToList();

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{"Id".PadRight(5)}|{"Name".PadRight(15)}|{"Price".PadRight(15)}|{"Date".PadRight(15)}|");
            Console.WriteLine("-----------------------------------------------------");

            // Display data using foreach loop
            foreach (var cat in catList)
            {
                if (cat == null) continue;
                Console.WriteLine($"{cat.id.ToString().PadRight(5)}|{cat.name.PadRight(15)}|{cat.price.ToString().PadRight(15)}|{cat.datetime.ToString("dd-MM-yyyy").PadRight(15)}|");
                Console.WriteLine("-----------------------------------------------------");
            }



            if (catList.Count >= 0)
            {
                CatOperation();
            }
        }
        public void CatOperation()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\n Cat Operations:");
            Console.WriteLine(" 1. Add Cat");
            Console.WriteLine(" 2. Update Cat");
            Console.WriteLine(" 3. Delete Cat");
            Console.WriteLine(" 4. Back to Previous Menu");
            Console.WriteLine(" 5. Back to Main Menu");
            Console.Write(" Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------");
            switch (choice)
            {
                case "1":
                    AddCat();
                    break;
                case "2":
                    UpdateCat();
                    break;
                case "3":
                    DeleteCat();
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

        public void AddCat()
        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter Cat name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter Cat Price: ");
                double price = double.Parse(Console.ReadLine());
                DateTime date = DateTime.Today;
                var cat = new Cat { type = "Cat", name = Name, price = price, datetime = date };
                context.cats.Add(cat);
                context.SaveChanges();
                Console.WriteLine("Cat added successfully.");
                Console.WriteLine();
                CatOperation();
            }
        }

        public void UpdateCat()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Cat ID to update: ");
                int catId = int.Parse(Console.ReadLine());
                var cat = context.cats.Find(catId);

                if (cat != null && cat.type == "Cat")
                {
                    Console.Write("Enter new Cat name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Cat Price: ");
                    double newPrice = double.Parse(Console.ReadLine());
                    DateTime newdate = DateTime.Today;
                    cat.name = newName;
                    cat.price = newPrice;
                    cat.datetime = newdate;
                    context.SaveChanges();
                    Console.WriteLine("Cat updated successfully.");
                    Console.WriteLine();
                    CatOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Cat ID or Cat type. Update failed.");
                }
            }
        }

        public void DeleteCat()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Cat ID to delete: ");
                int catId = int.Parse(Console.ReadLine());

                var cat = context.cats.Find(catId);

                if (cat != null && cat.type == "Cat")
                {
                    context.cats.Remove(cat);
                    context.SaveChanges();
                    Console.WriteLine("Cat deleted successfully.");
                    Console.WriteLine();
                    CatOperation();
                }
                else
                {
                    Console.WriteLine("Invalid Cat ID or Cat type. Deletion failed.");
                }
            }
        }
    }

}

