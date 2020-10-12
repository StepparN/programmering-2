using System;
using System.Collections.Generic;
using System.Text;

namespace polimorfidemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> cart = new List<Product>();

            Milk milk = new Milk();
            milk.FatContent = 1;
            milk.ProductNumber = 123;
            milk.StockStatus = 10;

            cart.Add(milk);

            Nocco nocco = new Nocco();
            nocco.Flavor = "Cola";
            nocco.ProductNumber = 234;
            nocco.StockStatus = 14;

            cart.Add(nocco);

            Coffee coffee = new Coffee();
            coffee.Roastyness = "Dark AF";
            coffee.ProductNumber = 321;
            coffee.StockStatus = 0;

            cart.Add(coffee);

        }
    }
}
            
        

