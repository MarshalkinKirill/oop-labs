using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Core.Types;
using Shops.Core.Exceptions;

namespace Shops.Core
{
    public class ShopManager
    {
        private readonly Dictionary<int, Product> productList = new Dictionary<int, Product>();
        private readonly Dictionary<int, Shop> shopList = new Dictionary<int, Shop>();
        private int idShopMaker = 1;
        private int idProductMaker = 1;

        public void CreateProduct(string _name)
        {
            productList.Add(idProductMaker, new Product(idProductMaker, _name, 0, 0));
            idProductMaker++;
        }

        public void CreateShop(string _name, string _address)
        {
            shopList.Add(idShopMaker, new Shop(idShopMaker, _name, _address));
            idShopMaker++;
        }

        public void AddProductToShop(Shop _shop, Product _product, int _quantity, int _price)
        {
            if (shopList.ContainsKey(_shop.Id))
            {
                if (productList.ContainsKey(_product.Id))
                {
                    if (_shop.ProductList.ContainsKey(_product.Id))
                    {
                        _shop.ProductList[_product.Id].Quantity += _quantity;
                        _shop.ProductList[_product.Id].Price = _price;
                    }
                    else
                    {
                        if (_quantity > 0)
                        {
                            _shop.AddProduct(_product, _quantity, _price);
                        }
                        else
                        {
                            throw new InsufficientQtyProductErrorException("Insufficient Qty Product");
                        }
                    }
                }
                else
                {
                    throw new UnknownProductErrorException("Not avaliable Product");
                }
            }
            else
            {
                throw new UnknownShopErrorException("Not avaliable shop");
            }
        }

        public int BuyABatchOfProducts(Shop _shop, Product _product, int _qty, Client _client)
        {
            int sum = 0;
            if (shopList.ContainsKey(_shop.Id))
            {
                if (_shop.ProductList.ContainsKey(_product.Id))
                {
                    if (_shop.ProductList[_product.Id].Quantity >= _qty)
                    {
                        if (_client.money >= _qty * _shop.ProductList[_product.Id].Price)
                        {
                            _shop.ProductList[_product.Id].Quantity -= _qty;
                            _client.money -= _qty * _shop.ProductList[_product.Id].Price;
                        }
                        else
                        {
                            throw new InsufficientAmountOfMoneyErrorException("client money is not enough");
                        }
                    }
                    else
                    {
                        throw new InsufficientQtyProductErrorException("Insufficient Qty Product");
                    }
                }
                else
                {
                    throw new UnknownProductErrorException("Not avaliable Product");
                }
            }
            else
            {
                throw new UnknownShopErrorException("Not avaliable shop");
            }
            return sum;
        }

        public void BuyABigBatchOfProducts(Shop _shop, List<(Product _product, int _qty)> _order, Client _client)
        {
            if (shopList.ContainsKey(_shop.Id))
            {
                int sum = 0;
                int c = 0;
                foreach ((Product _product, int _qty) el in _order)
                {
                    if (_shop.ProductList.ContainsKey(el._product.Id))
                    {
                        if (_shop.ProductList[el._product.Id].Quantity >= el._qty)
                        {
                            c++;
                            sum += _shop.ProductList[el._product.Id].Price * el._qty;
                        }
                    }
                }
                if (c != _order.Count)
                {
                    throw new ConditionsOfShoppingListNotSatisfiedErrorException("Conditions of shopping list not satisfied");
                }
                if (sum > _client.money)
                {
                    throw new InsufficientAmountOfMoneyErrorException("client money is not enough");
                }
                foreach ((Product _product, int _qty) el in _order)
                {
                    if (_shop.ProductList.ContainsKey(el._product.Id))
                    {
                        if (_shop.ProductList[el._product.Id].Quantity >= el._qty)
                        {
                            _shop.ProductList[el._product.Id].Quantity -= el._qty;
                        }
                    }
                }
                _client.money -= sum;
            }
            else
            {
                throw new UnknownShopErrorException("Not avaliable shop");
            }
        }
        public string FindCheapestShop(List<(Product _product, int _qty)> _order)
        {
            string cheapestShopName = "";
            int minSum = int.MaxValue;
            foreach (KeyValuePair<int, Shop> shop in shopList)
            {
                int sum = 0;
                int c = 0;
                foreach ((Product _product, int _qty) el in _order)
                {
                    if (shop.Value.ProductList.ContainsKey(el._product.Id))
                    {
                        if (el._qty <= shop.Value.ProductList[el._product.Id].Quantity)
                        {
                            sum += shop.Value.ProductList[el._product.Id].Price * el._qty;
                            c++;
                        }

                    }
                    else
                    {
                        break;
                    }
                }
                //Console.WriteLine(c);
                //Console.WriteLine(sum);
                //Console.WriteLine(shop.Value.Name);
                if (c == _order.Count)
                {
                    if (minSum > sum)
                    {
                        minSum = sum;
                        cheapestShopName = shop.Value.Name;
                    }
                }

            }
            if (cheapestShopName == "")
            {
                throw new NoShopSatisfyingShopingListErrorException("No shop satisfying shoping list");
            }
            return cheapestShopName;
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            return productList;
        }

        public Dictionary<int, Shop> GetAllShops()
        {
            return shopList;
        }
    }
}