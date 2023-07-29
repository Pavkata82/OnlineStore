using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Threading;

namespace OnlineStore.Classes
{
    internal class StoreMenu
    {

        public string logo = "   ____        ___               _____ __                \r\n  / __ \\____  / (_)___  ___     / ___// /_____  ________ \r\n / / / / __ \\/ / / __ \\/ _ \\    \\__ \\/ __/ __ \\/ ___/ _ \\\r\n/ /_/ / / / / / / / / /  __/   ___/ / /_/ /_/ / /  /  __/\r\n\\____/_/ /_/_/_/_/ /_/\\___/   /____/\\__/\\____/_/   \\___/ \r\n                                                         ";

        public Cart cart = new Cart();
        public Inventory inventory = new Inventory();
        public List<Order> orderHistory = new List<Order>();

        public void Start()
        {
            Clothes jeans = new Clothes(1, "jeans", 10, "XL");
            inventory.AddProduct(jeans);
            MainMenu();
        }
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Say("1", "Add new item into inventory");
            Say("2", "Print Inventory");
            Say("3", "Browse for product");
            Say("4", "My cart");
            Say("5", "Check out");
            Say("6", "Order history");
            Say("7", "Exit");
            int choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                AddItemTypeMenu();
            }
            else if (choise == 2)
            {
                int choiseReturn;

                do 
                { 
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);
                    Say("1", "Return to main menu");
                    inventory.PrintInventory();
                    choiseReturn = int.Parse(Console.ReadLine());
                    if (choiseReturn == 1)
                    { 
                        MainMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(logo, Color.BlueViolet);

                        Console.WriteLine("Invalid command!", Color.IndianRed);
                        Console.Write("Wait!", Color.Yellow);
                        Thread.Sleep(2000);
                    }
                } while (choiseReturn != 1);
            }
            else if (choise == 3)
            {
                BrowsingMenu();
            }
            else if (choise == 4)
            {
                CartMenu();
                
            }
            else if (choise == 5)
            {
                OrderMenu();
            }
            else if (choise == 6)
            {
                //empty cart
                if (orderHistory.Count() <= 0)
                {                
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Your cart is empty!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                }
                else
                {
                    PrintOrderHistory();
                }
                
            }
            else if (choise == 7)
            {
                Environment.Exit(1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
            }

        }
        public void AddItemTypeMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);
            Console.WriteLine("Type:");
            Say("1", "Electronics");
            Say("2", "Clothes");
            Say("3", "Books");
            int choiseType = int.Parse(Console.ReadLine());

            AddItemMeny(choiseType);
        }
        public void AddItemMeny(int choise)
        {
            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Enter ProductId (int): ");
                int productIdRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter name of the product: ");
                string nameRaw = Console.ReadLine();
                
                Console.Write("Enter product price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Enter SizeX (int): ");
                int sizeXRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter SizeY (int): ");
                int sizeYRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter Energy Usage (Wats): ");
                int energyUsageRaw = int.Parse(Console.ReadLine());

                Electronics electronic = new Electronics(productIdRaw,nameRaw,price,sizeXRaw,sizeYRaw,energyUsageRaw);

                inventory.AddProduct(electronic);

                Console.WriteLine("Successful added item!", Color.LightGreen);

                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);               

                MainMenu();
                return;
            }

            else if (choise == 2)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Enter ProductId (int): ");
                int productIdRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter name of the product: ");
                string nameRaw = Console.ReadLine();

                Console.Write("Enter product price: ");
                int priceRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter size (string): ");
                string sizeRaw = Console.ReadLine();

                Clothes cloth = new Clothes(productIdRaw, nameRaw, priceRaw, sizeRaw);

                inventory.AddProduct(cloth);

                Console.WriteLine("Successful added item!", Color.LightGreen);

                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);

                MainMenu();
                return;
            }
            else if (choise == 3)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Enter ProductId (int): ");
                int productIdRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter name of the product: ");
                string nameRaw = Console.ReadLine();

                Console.Write("Enter product price: ");
                int priceRaw = int.Parse(Console.ReadLine());

                Console.Write("Enter number of pages (int): ");
                int sizeRaw = int.Parse(Console.ReadLine());

                Books book = new Books(productIdRaw, nameRaw, priceRaw, sizeRaw);

                inventory.AddProduct(book);

                Console.WriteLine("Successful added item!", Color.LightGreen);

                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);

                MainMenu();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
            }
        }
        public void BrowsingMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Say("1", "Add product to cart");
            Say("2", "Browse for product");
            Say("3", "Main menu");


            int choiseBrowsing = int.Parse(Console.ReadLine());
            BrowsedMenu(choiseBrowsing);
        }
        public void BrowsedMenu(int choise)
        {

            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Enter Product Id that you want to add to cart: ");
                int id = int.Parse(Console.ReadLine());

                if (inventory.ReturnProductById(id) != null)
                {
                    cart.AddToCart(inventory.ReturnProductById(id));
                    Console.Write($"{inventory.ReturnProductById(id).name} successfully added to the cart!", Color.LightGreen);
                    Thread.Sleep(2000);
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Id!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                }
                
            }
            else if (choise == 2)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                inventory.BrowseForProduct();
                Console.Write("Press enter to continue...");
                Console.ReadKey();
                BrowsingMenu();
            }
            else if (choise == 3)
            {
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
            }
        }
        public void CartMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Say("1", "Extended cart");
            Say("2", "Remove product");
            Say("3", "Main menu");
            
            cart.PrintItemsInCart();
            Console.WriteLine("----------");
            Console.WriteLine($"Cart total price: {cart.TotalPriceOfCart()}");
            Console.WriteLine("----------");

            int choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Say("1", "Back to normal cart");
                Say("2", "Main menu");

                cart.ExtendedPrintItemsInCart();
                Console.WriteLine("----------");
                Console.WriteLine($"Cart total price: {cart.TotalPriceOfCart()}");
                Console.WriteLine("----------");

                int choiseExtendedCart = int.Parse(Console.ReadLine());

                if (choiseExtendedCart == 1)
                {
                    CartMenu();
                }
                else if (choiseExtendedCart == 2)
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid command!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    CartMenu();
                }
            }
            else if (choise == 2)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Remove product (product Id): ");
                int productId = int.Parse(Console.ReadLine());

                foreach (Product product in cart.cart)
                {
                    if (product.productId == productId)
                    {
                        cart.RemoveFromCart(product);
                        Console.Write($"{product.name} successfully removed from the cart!", Color.LightGreen);
                        Thread.Sleep(2000);
                        CartMenu();
                        break;
                    }
                }

                
            }
            else if (choise == 3)
            {
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
            }
        }
        public void OrderMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Order order = new Order();
            order.OrderInfo();
            Console.WriteLine("--Products--");
            cart.PrintItemsInCart();
            Console.WriteLine("----------");
            Console.WriteLine("Total price: " + cart.TotalPriceOfCart());
            Console.WriteLine("----------");

            Console.WriteLine("Do you want to finish your order:");
            Say("1", "Yes");
            Say("2", "No");
            int choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                order.EnterPurchasedProducts(cart.cart);

                order.PrintOrderDetail();

                orderHistory.Add(order);

                cart.RemoveAll();

                Console.Write("Pres Enter to return...");
                Console.ReadKey();
                MainMenu();
            }
            else if (choise == 2)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid command!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                OrderMenu();
            }
        }
        private void Say(string number, string message)
        {
            Console.Write("[");
            Console.Write(number, Color.BlueViolet);
            Console.WriteLine("]" + message);
        }
        private void PrintOrderHistory()
        {
            foreach (Order order in orderHistory)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                order.PrintOrderDetail();

                Console.Write("Pres Enter to return...");
                Console.ReadKey();
                MainMenu();
            }
        }
    }
}
