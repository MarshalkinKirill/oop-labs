using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Core
{
    public class Shop
    {
        public int Id;
        public string Name;
        private readonly string Address;
        public Dictionary<int, Product> ProductList;

        public Shop(int id, string name, string address)
        {
            Name = name;
            Id = id;
            Address = address;
            ProductList = new Dictionary<int, Product>();
        }

        public void AddProduct(Product _product, int _quantity, int _price)
        {
            if (ProductList.ContainsKey(_product.Id))
            {
                ProductList[_product.Id].Quantity += _product.Quantity;
                ProductList[_product.Id].Price = _product.Price;
            }
            else
            {
                ProductList.Add(_product.Id, new Product(_product.Id, _product.Name, _quantity, _price));
            }
        }


    }
}