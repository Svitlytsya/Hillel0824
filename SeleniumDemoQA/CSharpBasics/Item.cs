using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Item
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Item(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}
