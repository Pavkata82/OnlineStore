using OnlineStore.Classes;
using System.Transactions;

namespace OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Clothes shirt = new Clothes("L", 1, "shirt", 10);

            //Clothes jeans = new Clothes("XL", 1, "jeans", 10);

            //Electronics phone = new Electronics(12, "phone", 1000, 10, 10, 2);

            //Inventory inventory = new Inventory();            

            //Cart cart = new Cart();

            //inventory.AddProduct(shirt);
            //inventory.AddProduct(jeans);
            //inventory.AddProduct(phone);

            //inventory.PrintInventory();

            //Console.WriteLine(inventory.SearchProduct("phone").price);

            //inventory.TotalValue();

            //cart.AddToCart(shirt);
            //cart.AddToCart(shirt);
            //cart.AddToCart(phone);

            //cart.PrintItemsInCart();
            //Console.WriteLine(cart.TotalPriceOfCart());

            //inventory.BrowseForProduct();

            StoreMenu storeMenu = new StoreMenu();
            storeMenu.Start();

            //readkey
            Console.ReadKey();
        }
    }
}