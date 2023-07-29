using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Cart
    {
        public List<Product> cart = new List<Product>();

        public void AddToCart(Product product)
        {
            cart.Add(product);
        }
        public void RemoveFromCart(Product product)
        {
            cart.Remove(product);
        }
        public void RemoveAll()
        {
            cart.Clear();
        }
        public void PrintItemsInCart()
        {
            foreach (Product product in cart)
            {
                Console.WriteLine(product.name);
            }
        }
        public void ExtendedPrintItemsInCart()
        {
            foreach (Product product in cart)
            {
                Console.WriteLine("----------");

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
        }
        public int TotalPriceOfCart()
        {
            int total = 0;

            foreach (Product product in cart)
            {
                total += product.price;
            }
            return total;
        }
    }
}
