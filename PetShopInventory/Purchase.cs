using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory
{
    public class Purchase
    {
        public int Id { get; set; }
        public string? PetType { get; set; }
        public double Price { get; set; }
        public string? SellerContact { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
