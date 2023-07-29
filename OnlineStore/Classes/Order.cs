using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Order
    {
        public int orderId;
        public string customerName;
        public DateOnly date;
        public List<Product> purchased;

        public void OrderInfo()
        {
            Console.Write("Enter your name: ");
            this.customerName = Console.ReadLine();

            Console.Write("Enter date:");
            this.date = DateOnly.Parse(Console.ReadLine());
        }

        public void EnterPurchasedProducts(List<Product> cart)
        {
            this.purchased = cart;
        }

        public void PrintOrderDetail()
        {
            Random rnd = new Random();
            int random = rnd.Next(100, 100000);

            this.orderId = random;

            Console.WriteLine("----------");
            Console.WriteLine($"Order ID: {this.orderId}");
            Console.WriteLine($"Name: {this.customerName}");
            Console.WriteLine($"Date: {this.date}");          

            foreach (Product product in purchased)
            {
                
                Console.WriteLine("----------");

                if (product is Electronics)
                {
                    Electronics electronics = (Electronics)product;
                    Console.WriteLine($"ProductID: {electronics.productId}\nPrice: {electronics.price}\nSizeX: {electronics.sizeX}\n" +
                        $"SizeY: {electronics.sizeY}\nEnergy usage in Wats: {electronics.enegryUsage}");
                }
                else if (product is Clothes)
                {
                    Clothes cloth = (Clothes)product;
                    Console.WriteLine($"ProductID: {cloth.productId}\nPrice: {cloth.price}\nSize: {cloth.size}");
                }
                else if (product is Books)
                {
                    Books book = (Books)product;
                    Console.WriteLine($"ProductID: {book.productId}\nPrice: {book.price}\nPages: {book.pages}");
                }

                Console.WriteLine("----------");
            }
            Console.WriteLine("----------");
        }
    }
}
