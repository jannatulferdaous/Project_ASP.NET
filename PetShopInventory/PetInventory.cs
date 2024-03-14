namespace PetShopInventory
{
    public class PetInventory
    {
        public void Inventory()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\t 1. View Pets in Inventory");
                Console.WriteLine("\t 2. Manage Feeding Schedule");
                Console.WriteLine("\t 3. View Purchase");
                Console.WriteLine("\t 4. View Sale Details");
                Console.WriteLine("\t 5. View Monthly Sales Report");
                Console.WriteLine("\t 6. Change Password");
                Console.WriteLine("\t 7. Logout");
                Console.Write("\t Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewPetsInInventory();
                        break;
                    case "2":
                        ScheduleDetails scheduleDetails = new ScheduleDetails();
                        scheduleDetails.ManageSchedule();
                        break;
                    case "3":
                        PurchaseInfo purchase = new PurchaseInfo();
                        purchase.ManagePurchase();

                        break;
                    case "4":
                        SaleOpetation saleOpetation = new SaleOpetation();
                        saleOpetation.ManageSale();
                        break;
                    case "5":
                        MonthlyReport monthlyReport = new MonthlyReport();
                        monthlyReport.GenerateReport();
                        break;
                    case "6":
                        LoginInfo loginInfo = new LoginInfo();
                        loginInfo.ChangePassword(SessionUser.LoggedInUser);
                        break;
                    case "7":
                        SessionUser.LoggedInUser = null;
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
        }
        public void ViewPetsInInventory()
        {
            using (var context = new ShopDbContext())
            {
                var fishCount = context.Fish.Count();
                var catCount = context.cats.Count();
                var birdCount = context.Birds.Count();
                var dogCount = context.Dogs.Count();
                var chickenCount = context.Chickens.Count();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\n Type of Pets \t |   Number of Pets:");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"\t Cats:\t\t|\t{catCount} available pet(s)");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"\t Dogs:\t\t|\t{dogCount} available pet(s)");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"\t Fish:\t\t|\t{fishCount} available pet(s)");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"\t Birds:\t\t|\t{birdCount} available pet(s)");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"\t Chickens:\t|\t{chickenCount} available pet(s)");
                Console.WriteLine("------------------------------------------------");
            }
            PetDetails();
        }

        public void PetDetails()
        {
            Console.WriteLine("\n  View Details for each Pet Type:");
            Console.WriteLine("  1. View Cat Details");
            Console.WriteLine("  2. View Dog Details");
            Console.WriteLine("  3. View Fish Details");
            Console.WriteLine("  4. View Bird Details");
            Console.WriteLine("  5. View Chicken Details");
            Console.WriteLine("  6. View Back to main menu");
            Console.Write("  Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CatDetails catDetails = new CatDetails();
                    catDetails.ManageCatInfo();
                    break;
                case "2":
                    DogDetails dogDetails = new DogDetails();
                    dogDetails.ManageDogInfo();
                    break;
                case "3":
                    FishDetails fishDetails = new FishDetails();
                    fishDetails.ManageFishInfo();
                    break;
                case "4":
                    BirdDetails birdDetails = new BirdDetails();
                    birdDetails.ManageBirdInfo();
                    break;
                case "5":
                    ChickenDetails chickenDetails = new ChickenDetails();
                    chickenDetails.ManageChickenInfo();
                    break;
                case "6":
                    Inventory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
