using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace OnlineStore.Classes
{
    internal class Order
    {

        public int orderId;
        public string customerName;
        public DateOnly date;
        public int totalPrice;
        public List<Product> purchased;

        public void OrderInfo(string customerName, DateOnly date)
        {
            this.customerName = customerName;

            this.date = date;
        }
        public void GenerateOrderId()
        {
            Random rnd = new Random();
            int random = rnd.Next(100, 100000);

            this.orderId = random;
        }

        public void EnterPurchasedProducts(List<Product> cart)
        {
            this.purchased = cart;
        }

        public void PrintOrderDetail()
        {
            Console.WriteLine("----------");
            Console.WriteLine($"Order ID: {this.orderId}");
            Console.WriteLine($"Name: {this.customerName}");
            Console.WriteLine($"Date: {this.date}");
            Console.WriteLine($"Total price: {this.totalPrice}");

            Console.WriteLine("----------");

            foreach (Product product in purchased)
            {                

                if (product is Electronics)
                {
                    Electronics electronics = (Electronics)product;
                    Console.WriteLine($"ProductID: {electronics.productId}\nName: {electronics.name}\nPrice: {electronics.price}\nSizeX: {electronics.sizeX}\n" +
                        $"SizeY: {electronics.sizeY}\nEnergy usage in Wats: {electronics.enegryUsage}");
                }
                else if (product is Clothes)
                {
                    Clothes cloth = (Clothes)product;
                    Console.WriteLine($"ProductID: {cloth.productId}\nName: {cloth.name}\nPrice: {cloth.price}\nSize: {cloth.size}");
                }
                else if (product is Books)
                {
                    Books book = (Books)product;
                    Console.WriteLine($"ProductID: {book.productId}\nName: {book.name}\nPrice: {book.price}\nPages: {book.pages}");
                }

                Console.WriteLine("----------");
            }
            Console.WriteLine("=+=+=+=+=+", Color.BlueViolet);
        }
    }
}
