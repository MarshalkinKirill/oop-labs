using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Core
{
    public class Product
    {
        public int Id;
        public string Name;
        public int Quantity;
        public int Price;

        public Product(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }


        public Product(int _id, string _name, int _quantity, int _price)
        {
            Id = _id;
            Name = _name;
            Quantity = _quantity;
            Price = _price;
        }





    }
}
