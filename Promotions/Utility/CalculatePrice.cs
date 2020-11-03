using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Promotions.Models;

namespace Promotions.Utility
{
    public class CalculatePrice
    {
        public static List<PromotionModel> PriceDataForSKU()
        {
            List<PromotionModel> PriceDate = new List<PromotionModel>
            {
                new PromotionModel{SKU='A', Price = 50 },
                new PromotionModel{SKU='B', Price = 30 },
                new PromotionModel{SKU='C', Price = 20 },
                new PromotionModel{SKU='D', Price = 15 },
            };
            return PriceDate;
        }

        public int CalculateTotalPrice(List<CartItem> items)
        {
            int totalPrice = 0;
            foreach (var item in items)
            {
                //Promotion 1
                totalPrice = totalPrice + PromotionAB(item);
            }

            var matchedCItem = items.Where(x => x.SKU == 'C').FirstOrDefault();
            var matchedDItem = items.Where(x => x.SKU == 'D').FirstOrDefault();
            if (matchedCItem != null && matchedDItem!=null)
            {
                if(matchedCItem.Quantity <= matchedDItem.Quantity)
                {
                    totalPrice = totalPrice + (matchedCItem.Quantity * 30) + ((matchedDItem.Quantity - matchedCItem.Quantity) * 15);
                }
                else
                    totalPrice = totalPrice + (matchedDItem.Quantity * 30) + ((matchedCItem.Quantity - matchedDItem.Quantity) * 20);
            }

            return totalPrice;
        }

        public static int PromotionAB(CartItem item)
        {
            int totalPrice = 0;
            if (item.SKU == 'A' || item.SKU == 'B')
            {
                int groupingCount = 2, promotionPrice = 45;
                if (item.SKU == 'A')
                {
                    groupingCount = 3;
                    promotionPrice = 130;
                }

                int quantityWithPromotion = item.Quantity / groupingCount;
                int quantityWithoutPromotion = item.Quantity - (groupingCount * quantityWithPromotion);

                var matchedPriceData = PriceDataForSKU().Where(x => x.SKU == item.SKU).FirstOrDefault();

                totalPrice = totalPrice + (quantityWithoutPromotion * matchedPriceData.Price) + quantityWithPromotion * promotionPrice;
            }
            return totalPrice;
        }
    }
}
