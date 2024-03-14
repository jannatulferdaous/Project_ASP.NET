using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory
{
    public class LoginInfo
    {
        public void ChangePassword(User user)
        {
            using (var context = new ShopDbContext())
            {
                Console.Write("Enter current password: ");
                string currentPassword = Console.ReadLine();

                if (user.Password == currentPassword)
                {
                    Console.Write("Enter new password: ");
                    string newPassword = Console.ReadLine();
                    user.Password = newPassword;
                    context.SaveChanges();
                    Console.WriteLine("Password changed successfully.");
                }
                else
                {
                    Console.WriteLine("Incorrect current password. Password not changed.");
                }
            }
        }

        public User Login()
        {
            Console.WriteLine("                                ┌────────────────────────────┐");
            Console.Write("                                |   Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("                                └────────────────────────────┘");

            Console.WriteLine("                                ┌────────────────────────────┐");
            Console.Write("                                |   Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("                                └────────────────────────────┘");

            using (var context = new ShopDbContext())
            {
                return context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            }
        }

    }
}
