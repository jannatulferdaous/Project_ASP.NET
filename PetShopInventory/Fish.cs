﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PetShopInventory
{
    public class Fish
    {
        public int id {  get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
        public double price { get; set; }        
        public DateTime purchaseDate { get; set; }

    }
}
