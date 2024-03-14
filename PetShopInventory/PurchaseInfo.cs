using PetShopInventory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PetShopInventory
{
    public class PurchaseInfo
    {

        public void ManagePurchase()
        {
            bool continueManaging = true;

            while (continueManaging)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("=== Manage Purchase Information ===");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("  1. View All Purchase");
                Console.WriteLine("  2. Add New Purchase");
                Console.WriteLine("  3. Update Existing Purchase");
                Console.WriteLine("  4. Delete Purchase");
                Console.WriteLine(" 5. Back to Main Menu");
                Console.WriteLine("-------------------------------------");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllPurchase();
                        break;
                    case "2":
                        AddNewPurchase();
                        break;
                    case "3":
                        UpdatePurchase();
                        break;
                    case "4":
                        DeletePurchase();
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

        private void ViewAllPurchase()
        {
            ShopDbContext context = new ShopDbContext();
            List<Purchase> purchaseList = context.Purchases.ToList();

            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"{"\tId".PadRight(10)}|{"PetType".PadRight(15)}|{"Price".PadRight(15)}|{"SellerContact".PadRight(15)}|{"Date".PadRight(15)}|");
            Console.WriteLine("--------------------------------------------------------------------------------------");

            // Display data using foreach loop
            foreach (var purchase in purchaseList)
            {
                if (purchase == null) continue;
                Console.WriteLine($"\t{purchase.Id.ToString().PadRight(10)}|{purchase.PetType.PadRight(15)}|{purchase.Price.ToString().PadRight(15)}|{purchase.SellerContact.PadRight(15)}|{purchase.PurchaseDate.ToString("dd-MM-yyyy").PadRight(15)}| ");
                Console.WriteLine("--------------------------------------------------------------------------------------");
            }
            ManagePurchase(); //Console.WriteLine("-----------------------------------------------------");
        }

        public void AddNewPurchase()

        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter Pet Type: ");
                string PetName = Console.ReadLine();
                Console.Write("Enter  Pet Price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter Seller Contact: ");
                string contact = Console.ReadLine();
                Console.Write("Enter Purchase Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                var purchase = new Purchase
                {
                    PetType = PetName,
                    Price = price,
                    SellerContact = contact,
                    PurchaseDate = date,
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                Console.WriteLine(" Added successfully!");
                Console.WriteLine();
            }
            ManagePurchase();
        }


        public void UpdatePurchase()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter  ID to update: ");
                int Id = int.Parse(Console.ReadLine());
                var purchase = context.Purchases.Find(Id);
                if (purchase != null)
                {
                    Console.Write("Enter Pet Type: ");
                    string PetName = Console.ReadLine();
                    Console.Write("Enter  Pet Price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter Seller Contact: ");
                    string contact = Console.ReadLine();
                    Console.Write("Enter Purchase Date: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    purchase.PetType = PetName;
                    purchase.Price = price;
                    purchase.SellerContact = contact;
                    purchase.PurchaseDate = date;

                    context.SaveChanges();
                    Console.WriteLine(" updated successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Schedule ID . Update failed.");
                }
            }
            ManagePurchase();
        }

        public void DeletePurchase()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter Purchase ID to delete: ");
                int Id = int.Parse(Console.ReadLine());

                var purchase = context.Purchases.Find(Id);

                if (purchase != null)
                {
                    context.Purchases.Remove(purchase);
                    context.SaveChanges();
                    Console.WriteLine(" deleted successfully.");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Invalid ID. Deletion failed.");
                }
            }
            ManagePurchase();
        }
    }
}
  