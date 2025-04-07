using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Product
    {
        public int Id { get; set; }
        public Product(int productId)
        {
            Id = productId;
        }
    }
    public class Orders
    {

        public int OrderNumber { get; set; }

        private List<Product> _products;
        private DateTime _orderDate;
        private string _orderDescription;

        public Orders(int orderNumber)
        {
            OrderNumber = orderNumber;
        }


        public string GetDescription()
        {
            return _orderDescription;
        }

        public void AddDescription(string descr)
        {
            _orderDescription = descr;
        }

        public void AddProduct(Product product)
        {
            if (product.Id < 1)
            {
                throw new ArgumentException(nameof(product));
            }
            _products.Add(product);
        }



        //public int OrderNumber { get { return _orderNumber; } set { _orderNumber = value; } }
    }

    internal class OrderTest
    {
        [Test]
        public void OrderTest1()
        {
            var order1 = new Orders(2);
            var on = order1.OrderNumber;
            order1.OrderNumber = 3;
            //order1.SetOrderNumber(3);
            //var orderNumber = order1.GetOrderNumber();

            //order1.AddProduct(new Product(1));
            //order1._products.Add(new Product(2));

            Assert.That(order1.OrderNumber, Is.EqualTo(3));
        }

    }
}
