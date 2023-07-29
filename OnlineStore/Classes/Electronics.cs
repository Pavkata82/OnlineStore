using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Classes
{
    internal class Electronics : Product
    {
        public int sizeX;
        public int sizeY;
        public int enegryUsage;

        public Electronics() : base()
        {
            this.sizeX = 0;
            this.sizeY = 0;
            this.enegryUsage = 0;
        }
        public Electronics(int productId, string name, int price, int sizeX, int sizeY, int energyUsage) : base(productId, name, price)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.enegryUsage = energyUsage;
        }
    }
}
