using PetShopInventory;

class Program
{
    static void Main(string[] args)
    {
        // ShopDbContext context = new ShopDbContext();
        LoginInfo loginInfo = new LoginInfo();

        Console.WriteLine();
        // Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                          ┌─────────────--------***--------───────────────┐");
        Console.WriteLine("                          │     Pet Shop Inventory Management System      │");
        Console.WriteLine("                          ├────────────────-------------------────────────┤");
        Console.WriteLine();
        User loggedInUser = loginInfo.Login();
        if (loggedInUser == null)
        {
            Console.WriteLine("Invalid username or password. Exiting...");
            return;
        }
        else
        {
            SessionUser.LoggedInUser = loggedInUser;
        }
        PetInventory inventory = new PetInventory();
        inventory.Inventory();
    }
}








