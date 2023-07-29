using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Product
    {
        public int productId;
        public string name;
        public int price;

        public Product()
        {
            this.productId = 0;
            this.name = "";
            this.price = 0;
        }

        public Product(int productId, string name, int price)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"ProductId: {this.productId}\nName: {this.name}\nPrice: {this.price}");
        }
    }
}
