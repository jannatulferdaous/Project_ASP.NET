using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory
{
    public class SaleOpetation
    {
        public void ManageSale()
        {
            bool continueManaging = true;

            while (continueManaging)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("*** Manage Sale Information ***");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("  1. View All Sales");
                Console.WriteLine("  2. Add New Sales");
                Console.WriteLine("  3. Update Existing Sales");
                Console.WriteLine("  4. Delete Sales");
                Console.WriteLine("  5. Back to Main Menu");
                Console.WriteLine("-------------------------------------");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllSale();
                        break;
                    case "2":
                        AddNewSale();
                        break;
                    case "3":
                        UpdateSale();
                        break;
                    case "4":
                        DeleteSale();
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

        private void ViewAllSale()
        {
            ShopDbContext context = new ShopDbContext();
            List<Sale> saleList = context.Sales.ToList();

            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Id".PadRight(10)}|{"PetType".PadRight(15)}|{"Price".PadRight(15)}|{"BuyerContact".PadRight(15)}|{"Date".PadRight(15)}|");
            Console.WriteLine("-------------------------------------------------------------------------------------");


            foreach (var sales in saleList)
            {
                if (sales == null) continue;
                Console.WriteLine($"{sales.Id.ToString().PadRight(5)}|{sales.PetType.PadRight(15)}|{sales.Price.ToString().PadRight(15)}|{sales.BuyerContact.PadRight(15)}|{sales.SaleDate.ToString("dd-MM-yyyy").PadRight(15)}| ");
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
            ManageSale();
        }

        public void AddNewSale()

        {
            using (var context = new ShopDbContext())
            {

                Console.Write("Enter PetType: ");
                string PetName = Console.ReadLine();
                Console.Write("Enter  PetPrice: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter Seller Contact: ");
                string contact = Console.ReadLine();
                Console.Write("Enter Purchase Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                var sale = new Sale
                {
                    PetType = PetName,
                    Price = price,
                    BuyerContact = contact,
                    SaleDate = date,
                };

                context.Sales.Add(sale);
                context.SaveChanges();
                Console.WriteLine(" Added successfully!");
                Console.WriteLine();
            }
            ManageSale();
        }


        public void UpdateSale()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter  ID to update: ");
                int Id = int.Parse(Console.ReadLine());
                var sale = context.Sales.Find(Id);
                if (sale != null)
                {
                    Console.Write("Enter PetType: ");
                    string PetName = Console.ReadLine();
                    Console.Write("Enter  PetPrice: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter Buyer Contact: ");
                    string contact = Console.ReadLine();
                    Console.Write("Enter Purchase Date: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    sale.PetType = PetName;
                    sale.Price = price;
                    sale.BuyerContact = contact;
                    sale.SaleDate = date;

                    context.SaveChanges();
                    Console.WriteLine(" updated successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Schedule ID . Update failed.");
                }
            }
            ManageSale();
        }

        public void DeleteSale()
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter sale ID to delete: ");
                int Id = int.Parse(Console.ReadLine());

                var sale = context.Sales.Find(Id);

                if (sale != null)
                {
                    context.Sales.Remove(sale);
                    context.SaveChanges();

                    Console.WriteLine(" deleted successfully.");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Invalid ID. Deletion failed.");
                }
            }
            ManageSale();
        }

    }
}
