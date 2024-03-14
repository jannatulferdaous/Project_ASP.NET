using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PetShopInventory
{
    enum Month
    {
        January = 01,
        February = 02,
        March = 03,
        April = 04,
        May = 05,
        June = 06,
        July = 07,
        August =08,
        September = 09,
        October = 10,
        November = 11,
        December = 12
    }

    public class MonthlyReport
    {
       public void GenerateReport()
         {
            Console.Write("Enter Month Name (e.g., January): ");
            string monthName = Console.ReadLine();
            string MonthName=GetValidMonthNameInput(monthName);
            Console.Write("Enter Year: ");
            string year = Console.ReadLine();
            int Year= GetValidIntInput(year);

            using (var context = new ShopDbContext())
               {
                  // Get the month number for filtering
                  int month = (int)Enum.Parse(typeof(Month), MonthName, true);

                  // Display purchase data
                    Console.WriteLine($"\t\t\t\t** Purchases for {MonthName}  {Year}  ");
                    Console.WriteLine("\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    var purchases = context.Purchases.Where(p => p.PurchaseDate.Month == month && p.PurchaseDate.Year == Year).ToList();
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine($"{"\t| Date".PadRight(15)}|{"Contact".PadRight(15)}| {"Pet Type".PadRight(15)}|{"price".PadRight(15)}  ");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    foreach (Purchase purchase in purchases)
                        {
                        Console.WriteLine($"{purchase.PurchaseDate.ToString().PadRight(10)}|{purchase.SellerContact.PadRight(15)}|{purchase.PetType.PadRight(15).PadLeft(10)}|{purchase.Price}|");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                    }

                    Console.WriteLine($"\t\t\t\t** Sales for {MonthName}  {Year}  ");
                    Console.WriteLine("\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    var sales = context.Sales.Where(s => s.SaleDate.Month == month && s.SaleDate.Year == Year).ToList();
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine($"{"\t| Date".PadRight(15)}|{"Contact".PadRight(15)}| {"Pet Type".PadRight(15)}|{"price".PadRight(15)}  ");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    foreach (Sale sale in sales)
                    {
                        Console.WriteLine($"{sale.SaleDate.ToString().PadRight(10)}|{sale.BuyerContact.PadRight(15)}|{sale.PetType.PadRight(15)}|{sale.Price}|");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                    }
                       
                    Console.WriteLine("\n** Summary **");
                    double totalPurchases = purchases.Sum(p => p.Price);
                    double totalSales = sales.Sum(s => s.Price);
                    double  profit = totalSales - totalPurchases;
                    Console.WriteLine($"Total purchases in this month  {totalPurchases:C2}");
                    Console.WriteLine();
                    Console.WriteLine($"Total sales in this month  {totalSales:C2}");
                    Console.WriteLine();
                    Console.WriteLine($"Total profit in this month  {profit:C2}");
             }
       }

        private string GetValidMonthNameInput(string prompt)
        {
            while (true)
            {
                string monthName = prompt.Trim().ToLower();

                try
                {
                    // Attempt to parse the month name using the Month enum
                    Enum.Parse(typeof(Month), monthName, true);
                    return monthName;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid month name. Please enter a valid month (e.g., January, February, etc.)");
                }
            }
        }

        private int GetValidIntInput(string prompt)
        {
            while (true)
            {
                string input = prompt;

                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }
        }



    }
}
