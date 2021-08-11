using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore_In_Wpf.Models
{
    public class Order
    {
        public String Name { get; set; }
        public decimal Sum { get; set; }
        public String ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
