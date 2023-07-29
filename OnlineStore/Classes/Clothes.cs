using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Clothes : Product
    {
        public string size;

        public Clothes(int productId, string name, int price, string size) : base(productId, name, price)
        {
            this.size = size;
        }
    }
}
