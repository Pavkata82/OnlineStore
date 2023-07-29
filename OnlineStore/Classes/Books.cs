using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Books : Product
    {
        public int pages;

        public Books(int productId, string name, int price, int pages) : base(productId,name,price)
        {
            this.pages = pages;
        }
    }
}
