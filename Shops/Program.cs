using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Core.Types;
using Shops.Core;

namespace Shops
{
    internal class Program
    {
        private static void Main()
        {
            var shopManager = new ShopManager();
            Client client = new Client("Kirill", 1000);
            shopManager.CreateProduct("product 1");
            shopManager.CreateProduct("product 2");
            shopManager.CreateProduct("product 3");
            shopManager.CreateProduct("product 4");
            shopManager.CreateProduct("product 5");

            shopManager.CreateShop("shop 1", "Saint-Petersburg, 1");

            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[1], 5, 100);
            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[2], 5, 20);

            List<(Product product, int quantity)> myList = new List<(Product product, int quantity)>();
            myList.Add((shopManager.GetAllProducts()[1], 2));
            myList.Add((shopManager.GetAllProducts()[2], 2));

            shopManager.BuyABigBatchOfProducts(shopManager.GetAllShops()[1], myList, client);

            Console.WriteLine(client.money);
            Console.ReadLine();
        }
    }
}
