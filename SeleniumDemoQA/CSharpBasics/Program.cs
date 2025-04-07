using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    class Program
    {
        static void Main()
        {
            var order = new Order(
                new Item[]
                {
                    new Item(100, 2),
                    new Item(200, 1)
                },
                new Discount("percentage", 10),
                7);

            Console.WriteLine($"Total Order Price: {order.CalculateTotalOrder()}");
        }
    }
}
