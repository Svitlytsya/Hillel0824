using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Order
    {
        public Item[] Items { get; set; }
        public Discount Discount { get; set; }
        public decimal Tax { get; set; }

        public Order(Item[] items, Discount discount, decimal tax)
        {
            this.Items = items;
            this.Discount = discount;
            this.Tax = tax;
        }

        public decimal CalculateTotalOrder()
        {
            // 1. Обчислення суми товарів
            decimal totalOrder = Items.Sum(item => item.Price * item.Quantity);

            // 2. Застосування знижки
            if (Discount != null)
            {
                if (Discount.Type == "fixed")
                    totalOrder -= Discount.Value;
                else if (Discount.Type == "percentage")
                    totalOrder -= totalOrder * (Discount.Value / 100);
            }

            // 3. Додавання податку
            decimal taxAmount = totalOrder * (Tax / 100);
            totalOrder += taxAmount;

            // 4. Округлення до 2 знаків після коми
            return Math.Round(totalOrder, 2);
        }
    }
}
