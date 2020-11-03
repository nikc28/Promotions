using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promotions.Models;
using Promotions.Utility;

namespace Promotions
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the count of distinct SKUs in Cart");
            int itemsCount;
            Int32.TryParse(Console.ReadLine(), out itemsCount);
            List<CartItem> items = new List<CartItem>();
            for (int i = 0; i < itemsCount; i++)
            {
                char SKU;
                Char.TryParse(Console.ReadLine(), out SKU);
                int count;
                Int32.TryParse(Console.ReadLine(), out count);
                CartItem item = new CartItem { SKU = SKU, Quantity = count };
                items.Add(item);
            }
            CalculatePrice calculatePrice = new CalculatePrice();
            Console.WriteLine(calculatePrice.CalculateTotalPrice(items));
            Console.ReadKey();
        }

        

    }
}
