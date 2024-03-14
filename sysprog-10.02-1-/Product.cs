using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysprog_10._02_1_
{
    public class Product
    {

        public string vendor;
        public string price;
        public string name;
        public string image;

        public Product(string vendor, string name, string price, string image)
        {
            this.name = name;
            this.image = image;     
            this.vendor = vendor;
            this.price = price;
        }
    }
}
