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

        //initializing of the 
        public Cart cart = new Cart();
        public Inventory inventory = new Inventory();
        public List<Order> orderHistory = new List<Order>();

        public void Start()
        {
            //predefined products in the inventory
            Clothes jeans = new Clothes(1, "jeans", 10, "XL");
            Clothes tshirt = new Clothes(2, "tshirt", 20, "L");
            inventory.AddProduct(jeans);
            inventory.AddProduct(tshirt);
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

            int choise;
            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 7)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command! Please enter a valid option (1-7).", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
                return;
            }

            if (choise == 1)
            {
                AddItemTypeMenu();
            }
            else if (choise == 2)
            {
                int choiseReturn;

                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Say("1", "Return to main menu");
                inventory.PrintInventory();

                bool isValidInputInternal = int.TryParse(Console.ReadLine(), out choiseReturn);
                if (!isValidInputInternal || choiseReturn != 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }


                if (choiseReturn == 1)
                { 
                    MainMenu();
                }
                
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
                if (cart.cart.Count != 0)
                {
                    OrderMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Your cart is empty!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                }
            }
            else if (choise == 6)
            {
                //empty cart
                if (orderHistory.Count() <= 0)
                {                
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("You dont have any orders yet!", Color.IndianRed);
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

        }
        public void AddItemTypeMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);
            Console.WriteLine("Type:");
            Say("1", "Electronics");
            Say("2", "Clothes");
            Say("3", "Books");

            int choiseType;
            bool isValidInput = int.TryParse(Console.ReadLine(), out choiseType);
            if (!isValidInput || choiseType < 1 || choiseType > 3)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command! Please enter a valid option (1-3).", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
                return;
            }

            AddItemMeny(choiseType);
        }
        public void AddItemMeny(int choise)
        {
            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Enter ProductId (int): ");
                int productIdRaw;
                bool isValidInput1 = int.TryParse(Console.ReadLine(), out productIdRaw);
                if (!isValidInput1 || productIdRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter name of the product: ");
                string nameRaw = Console.ReadLine();
                if (nameRaw == null || nameRaw == "")
                {
                    Console.WriteLine("The name must contain letter/s!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                }

                Console.Write("Enter product price: ");
                int priceRaw;
                bool isValidInput2 = int.TryParse(Console.ReadLine(), out priceRaw);
                if (!isValidInput2 || priceRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter SizeX (int): ");
                int sizeXRaw;
                bool isValidInput3 = int.TryParse(Console.ReadLine(), out sizeXRaw);
                if (!isValidInput3 || sizeXRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter SizeY (int): ");
                int sizeYRaw;
                bool isValidInput4 = int.TryParse(Console.ReadLine(), out sizeYRaw);
                if (!isValidInput4 || sizeYRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter Energy Usage (Wats): ");
                int energyUsageRaw;
                bool isValidInput5 = int.TryParse(Console.ReadLine(), out energyUsageRaw);
                if (!isValidInput5 || energyUsageRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Electronics electronic = new Electronics(productIdRaw,nameRaw,priceRaw,sizeXRaw,sizeYRaw,energyUsageRaw);

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
                int productIdRaw;
                bool isValidInput1 = int.TryParse(Console.ReadLine(), out productIdRaw);
                if (!isValidInput1 || productIdRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter name of the product: ");
                string nameRaw = Console.ReadLine();
                if (nameRaw == null || nameRaw == "")
                {
                    Console.WriteLine("The name must contain letter/s!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                }

                Console.Write("Enter product price: ");
                int priceRaw;
                bool isValidInput2 = int.TryParse(Console.ReadLine(), out priceRaw);
                if (!isValidInput2 || priceRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter size (XS/S/M/L/XL/XXL): ");
                string sizeRaw = Console.ReadLine().ToUpper();
                if (sizeRaw != "XS" && sizeRaw != "S" && sizeRaw != "M" && sizeRaw != "L" && sizeRaw != "XL" && sizeRaw != "XXL")
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("No such size!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);

                    MainMenu();
                }

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
                int productIdRaw;
                bool isValidInput1 = int.TryParse(Console.ReadLine(), out productIdRaw);
                if (!isValidInput1 || productIdRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter name of the product: ");
                string nameRaw = Console.ReadLine();
                if (nameRaw == null || nameRaw == "")
                {
                    Console.WriteLine("The name must contain letter/s!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                }

                Console.Write("Enter product price: ");
                int priceRaw;
                bool isValidInput2 = int.TryParse(Console.ReadLine(), out priceRaw);
                if (!isValidInput2 || priceRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Console.Write("Enter number of pages (int): ");
                int sizeRaw;
                bool isValidInput3 = int.TryParse(Console.ReadLine(), out sizeRaw);
                if (!isValidInput3 || sizeRaw < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                Books book = new Books(productIdRaw, nameRaw, priceRaw, sizeRaw);

                inventory.AddProduct(book);

                Console.WriteLine("Successful added item!", Color.LightGreen);

                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);

                MainMenu();
                return;
            }
        }
        public void BrowsingMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Say("1", "Add product to cart");
            Say("2", "Browse for product");
            Say("3", "Main menu");


            int choise;
            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 3)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command! Please enter a valid option (1-3).", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
                return;
            }

            BrowsedMenu(choise);
        }
        public void BrowsedMenu(int choise)
        {

            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Enter Product Id that you want to add to cart: ");

                int id;
                bool isValidInput = int.TryParse(Console.ReadLine(), out id);
                if (!isValidInput || id < 1)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

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
        }
        public void CartMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Say("1", "Extended cart");
            Say("2", "Remove product");
            Say("3", "Main menu");
            
            cart.PrintItemsInCart();
            Console.WriteLine();
            Console.WriteLine($"Cart total price: {cart.TotalPriceOfCart()}");
            Console.WriteLine("----------");

            int choise;
            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 3)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
                return;
            }

            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Say("1", "Back to normal cart");
                Say("2", "Main menu");

                cart.ExtendedPrintItemsInCart();
                Console.WriteLine();
                Console.WriteLine($"Cart total price: {cart.TotalPriceOfCart()}");
                Console.WriteLine("----------");

                int choiseInternal;
                bool isValidInputInternal = int.TryParse(Console.ReadLine(), out choiseInternal);
                if (!isValidInputInternal || choiseInternal < 1 || choiseInternal > 2)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option (1-2).", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                if (choiseInternal == 1)
                {
                    CartMenu();
                }
                else if (choiseInternal == 2)
                {
                    MainMenu();
                }
            }
            else if (choise == 2)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.Write("Remove product (product Id): ");
                int productId;
                bool isValidInputInternal = int.TryParse(Console.ReadLine(), out productId);
                if (!isValidInputInternal || productId < 1 || productId > 7)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("Invalid command! Please enter a valid option.", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    MainMenu();
                    return;
                }

                bool flag = false;

                foreach (Product product in cart.cart)
                {
                    if (product.productId == productId)
                    {
                        cart.RemoveFromCart(product);
                        Console.Write($"{product.name} successfully removed from the cart!", Color.LightGreen);
                        Thread.Sleep(2000);
                        CartMenu();
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine(logo, Color.BlueViolet);

                    Console.WriteLine("There is no such product!", Color.IndianRed);
                    Console.Write("Wait!", Color.Yellow);
                    Thread.Sleep(2000);
                    CartMenu();
                }

                
            }
            else if (choise == 3)
            {
                MainMenu();
            }
        }
        public void OrderMenu()
        {
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            Order order = new Order();
            order.GenerateOrderId();

            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            if (customerName == null || customerName == "")
            {
                Console.WriteLine("The name must contain letter/s!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
            }

            DateOnly date;

            Console.Write("Enter date:");

            bool dateBool = DateOnly.TryParse(Console.ReadLine(), out date);
            if (!dateBool)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid date!", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
            }

            order.OrderInfo(customerName, date);


            Console.WriteLine("--Products--");
            cart.PrintItemsInCart();
            Console.WriteLine();
            Console.WriteLine("Total price: " + cart.TotalPriceOfCart());
            Console.WriteLine("----------");

            Console.WriteLine("Do you want to finish your order:");
            Say("1", "Yes");
            Say("2", "No");
            int choise;
            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 2)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                Console.WriteLine("Invalid command! Please enter a valid option (1-2).", Color.IndianRed);
                Console.Write("Wait!", Color.Yellow);
                Thread.Sleep(2000);
                MainMenu();
                return;
            }

            if (choise == 1)
            {
                Console.Clear();
                Console.WriteLine(logo, Color.BlueViolet);

                List<Product> cartCopy = new List<Product>(cart.cart);

                order.EnterPurchasedProducts(cartCopy);

                order.totalPrice = cart.TotalPriceOfCart();

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
            Console.Clear();
            Console.WriteLine(logo, Color.BlueViolet);

            int count = 1;

            Console.WriteLine("=+=+=+=+=+", Color.BlueViolet);

            foreach (Order order in orderHistory)
            {
                Console.WriteLine($"--Order: {count}--");
                order.PrintOrderDetail();
                count++;
            }

            Console.Write("Pres Enter to return...");
            Console.ReadKey();
            MainMenu();
        }
    }
}
