using OnlineStore.Classes;
using System.Transactions;

namespace OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StoreMenu storeMenu = new StoreMenu();
            storeMenu.Start();

            //readkey
            Console.ReadKey();
        }
    }
}