using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Models
{
    public class CartItem
    {
        public char SKU { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
