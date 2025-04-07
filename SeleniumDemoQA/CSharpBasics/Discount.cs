using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Discount
    {
        public string Type { get; set; }
        public decimal Value { get; set; }

        public Discount(string type, decimal value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
