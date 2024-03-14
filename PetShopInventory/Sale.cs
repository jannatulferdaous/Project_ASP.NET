using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory
{
    internal class Sale
    {
        public int Id { get; set; }
        public string? PetType { get; set; }
        public double Price { get; set; }
        public string? BuyerContact { get; set; }
        public DateTime SaleDate { get; set; }
    }
}

