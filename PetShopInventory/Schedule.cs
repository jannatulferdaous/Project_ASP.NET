using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory
{
    public class Schedule
    {
        public int id {  get; set; }
        public string? petsname { get; set; }
        public string?  mealsPerDay { get; set;}
        public string? morningTime {  get; set; }
        public string?  noonTime { get; set; }
        public string? eveningTime  { get; set; }   
        public string? foodItem { get; set; }
    }
}
