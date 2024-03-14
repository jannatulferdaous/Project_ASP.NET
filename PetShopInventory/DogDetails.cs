using Microsoft.Identity.Client;
using System;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategor
namespace PetShopInventory;
public class DogDetails
{
    public void ManageDogInfo()
    {
        ShopDbContext context = new ShopDbContext();
        List<Dog> dogList = context.Dogs.ToList();

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"{"Id".PadRight(5)}|{"Name".PadRight(15)}|{"Price".PadRight(15)}|{"Date".PadRight(15)}|");
        Console.WriteLine("-----------------------------------------------------");

        // Display data using foreach loop
        foreach (var dog in dogList)
        {
            if (dog == null) continue;
            Console.WriteLine($"{dog.id.ToString().PadRight(5)}|{dog.name.PadRight(15)}|{dog.price.ToString().PadRight(15)}|{dog.datetime.ToString("dd-MM-yyyy").PadRight(15)}|");
            Console.WriteLine("-----------------------------------------------------");
        }



        if (dogList.Count >= 0)
        {
            DogOperation();
        }



    }
    public void DogOperation()
    {
        Console.WriteLine("\n Dog Operations:");
        Console.WriteLine(" 1. Add Dog");
        Console.WriteLine(" 2. Update Dog");
        Console.WriteLine(" 3. Delete Dog");
        Console.WriteLine(" 4. Back to Previous Menu");
        Console.WriteLine(" 5. Back to Main Menu");
        Console.Write(" Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddDog();
                break;
            case "2":
                UpdateDog();
                break;
            case "3":
                DeleteDog();
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

    public void AddDog()
    {
        using (var context = new ShopDbContext())
        {

            Console.Write("Enter Dog name: ");
            string dogName = Console.ReadLine();
            Console.Write("Enter Dog Price: ");
            double price = double.Parse(Console.ReadLine());
            DateTime date = DateTime.Today;

            var dog = new Dog { type = "Dog", name = dogName, price = price, datetime = date };
            context.Dogs.Add(dog);
            context.SaveChanges();

            Console.WriteLine("Dog added successfully.");
            Console.WriteLine();
            DogOperation();
        }
    }

    public void UpdateDog()
    {
        using (var context = new ShopDbContext())
        {
            Console.Write("Enter Dog ID to update: ");
            int dogId = int.Parse(Console.ReadLine());

            var dog = context.Dogs.Find(dogId);

            if (dog != null && dog.type == "Dog")
            {
                Console.Write("Enter new Dog name: ");
                string newDogName = Console.ReadLine();
                Console.Write("Enter new Dog Price: ");
                double newPrice = double.Parse(Console.ReadLine());
                DateTime newdate = DateTime.Today;
                dog.name = newDogName;
                dog.price = newPrice;
                dog.datetime = newdate;
                context.SaveChanges();

                Console.WriteLine("Dog updated successfully.");
                Console.WriteLine();
                DogOperation();
            }
            else
            {
                Console.WriteLine("Invalid Dog ID or Dog type. Update failed.");
            }
        }
    }

    public void DeleteDog()
    {
        using (var context = new ShopDbContext())
        {
            Console.Write("Enter Dog ID to delete: ");
            int dogId = int.Parse(Console.ReadLine());

            var dog = context.Dogs.Find(dogId);

            if (dog != null && dog.type == "Dog")
            {
                context.Dogs.Remove(dog);
                context.SaveChanges();

                Console.WriteLine("Dog deleted successfully.");
                Console.WriteLine();
                DogOperation();
            }
            else
            {
                Console.WriteLine("Invalid Dog ID or Dog type. Deletion failed.");
            }
        }
    }
}
