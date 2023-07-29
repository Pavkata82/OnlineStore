using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Inventory
    {
        public List<Product> inventory = new List<Product>();

        public void AddProduct(Product product)
        {
            inventory.Add(product);
        }
        public void PrintInventory()
        {
            Console.WriteLine("----------");
            foreach (Product product in inventory)
            {
                Console.WriteLine("Name: " + product.name);
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
        }
        public Product SearchProduct(string name)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory.ElementAt(i).name == name)
                    return inventory.ElementAt(i);
            }
            return null;
        }
        public Product ReturnProductById(int productId)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory.ElementAt(i).productId == productId)
                    return inventory.ElementAt(i);
            }
            return null;
        }
        public void BrowseForProduct()
        {
            Console.Write("Search product: ");
            string searchedProduct = Console.ReadLine().ToLower();

            foreach (Product product in inventory)
            {
                if (product.name == searchedProduct)
                {
                    Console.WriteLine("----------");

                    Console.WriteLine($"{searchedProduct} is avaliable!");
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
            }
            


            Console.WriteLine($"{searchedProduct} is not avaliable!");
        }
        public void TotalValue()
        {
            int value = 0;
            foreach (Product product in inventory)
            {
                value += product.price;
            }
            Console.WriteLine($"Total price: {value}");
        }
    }
}
