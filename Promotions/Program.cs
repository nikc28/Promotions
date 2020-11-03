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
            
            int itemsCount=0;
            do
            {
                Console.WriteLine("Please enter the count of distinct SKUs in Cart, should be more than 0");
                Int32.TryParse(Console.ReadLine(), out itemsCount);
            }
            while (itemsCount == 0);
            List<CartItem> items = new List<CartItem>();
            for (int i = 0; i < itemsCount; i++)
            {
                char SKU;
                string inputString = Console.ReadLine();
                if(!Char.TryParse(inputString, out SKU))
                {
                    SKU = Char.Parse(inputString.Substring(0, 1));
                }
                int count;
                Int32.TryParse(Console.ReadLine(), out count);
                CartItem item = new CartItem { SKU = SKU, Quantity = count };
                items.Add(item);
            }

            items.GroupBy(x => x.SKU).Select(x => new CartItem { SKU = x.Key, Quantity = x.Sum(y => y.Quantity) }).ToList();
            CalculatePrice calculatePrice = new CalculatePrice();
            Console.WriteLine(calculatePrice.CalculateTotalPrice(items));
            Console.ReadKey();
        }

        

    }
}
