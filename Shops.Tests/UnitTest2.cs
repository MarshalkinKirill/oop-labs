using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shops.Core;
using System.Collections.Generic;

namespace Shop.tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void test1()
        {
            var shopManager = new ShopManager();

            shopManager.CreateProduct("product 1");

            shopManager.CreateShop("shop 1", "Saint-Petersburg, 1");
            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[1], 5, 100);

            Assert.AreEqual("shop 1", shopManager.GetAllShops()[1].Name);
            Assert.AreEqual("product 1", shopManager.GetAllShops()[1].ProductList[1].Name);
        }

        [TestMethod]
        public void test2()
        {
            var shopManager = new ShopManager();

            shopManager.CreateProduct("product 1");

            shopManager.CreateShop("shop 1", "Saint-Petersburg, 1");

            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[1], 5, 100);
            Assert.AreEqual("product 1", shopManager.GetAllShops()[1].ProductList[1].Name);
            Assert.AreEqual(5, shopManager.GetAllShops()[1].ProductList[1].Quantity);
            Assert.AreEqual(100, shopManager.GetAllShops()[1].ProductList[1].Price);

            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[1], 10, 20);
            Assert.AreEqual("product 1", shopManager.GetAllShops()[1].ProductList[1].Name);
            Assert.AreEqual(15, shopManager.GetAllShops()[1].ProductList[1].Quantity);
            Assert.AreEqual(20, shopManager.GetAllShops()[1].ProductList[1].Price);
        }

        [TestMethod]
        public void test3()
        {
            var shopManager = new ShopManager();

            shopManager.CreateProduct("product 1");
            shopManager.CreateProduct("product 2");
            shopManager.CreateProduct("product 3");
            shopManager.CreateProduct("product 4");
            shopManager.CreateProduct("product 5");
            shopManager.CreateProduct("product 6");
            shopManager.CreateProduct("product 7");
            shopManager.CreateProduct("product 8");
            shopManager.CreateProduct("product 9");
            shopManager.CreateProduct("product 3");

            shopManager.CreateShop("shop 1", "Saint-Petersburg, 1");
            shopManager.CreateShop("shop 2", "Saint-Petersburg, 3");
            shopManager.CreateShop("shop 3", "Saint-Petersburg, 2");

            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[1], 5, 100);
            shopManager.AddProductToShop(shopManager.GetAllShops()[1], shopManager.GetAllProducts()[2], 5, 20);
            shopManager.AddProductToShop(shopManager.GetAllShops()[2], shopManager.GetAllProducts()[1], 5, 110);
            shopManager.AddProductToShop(shopManager.GetAllShops()[2], shopManager.GetAllProducts()[2], 5, 15);
            shopManager.AddProductToShop(shopManager.GetAllShops()[2], shopManager.GetAllProducts()[3], 5, 1);
            shopManager.AddProductToShop(shopManager.GetAllShops()[2], shopManager.GetAllProducts()[4], 5, 2);
            shopManager.AddProductToShop(shopManager.GetAllShops()[2], shopManager.GetAllProducts()[5], 5, 3);
            shopManager.AddProductToShop(shopManager.GetAllShops()[2], shopManager.GetAllProducts()[6], 5, 4);
            shopManager.AddProductToShop(shopManager.GetAllShops()[3], shopManager.GetAllProducts()[1], 5, 90);
            shopManager.AddProductToShop(shopManager.GetAllShops()[3], shopManager.GetAllProducts()[6], 5, 3);
            shopManager.AddProductToShop(shopManager.GetAllShops()[3], shopManager.GetAllProducts()[7], 5, 2);
            shopManager.AddProductToShop(shopManager.GetAllShops()[3], shopManager.GetAllProducts()[9], 5, 6);

            List<(Product product, int quantity)> myList = new List<(Product product, int quantity)>();
            myList.Add((shopManager.GetAllProducts()[1], 2));
            myList.Add((shopManager.GetAllProducts()[2], 2));

            string name = shopManager.FindCheapestShop(myList);
            Assert.AreEqual("shop 1", name);

            myList.Add((shopManager.GetAllProducts()[3], 10));
            Action acrual = () => shopManager.FindCheapestShop(myList);
            Assert.ThrowsException<Exception>(acrual);
        }

        [TestMethod]
        public void test4()
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

            Assert.AreEqual(3, shopManager.GetAllShops()[1].ProductList[1].Quantity);
            Assert.AreEqual(760, client.money);

            myList.Add((shopManager.GetAllProducts()[3], 2));
            Action acrual = () => shopManager.BuyABigBatchOfProducts(shopManager.GetAllShops()[1], myList, client);
            Assert.ThrowsException<Exception>(acrual);
        }
    }
}