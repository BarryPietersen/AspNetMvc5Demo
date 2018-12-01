using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemo.Models;

namespace MvcDemo
{
    public static class Data
    {
        public static Random _random = new Random();
        public static int GetRandomID => _random.Next(100, 999);

        public static List<Product> Products = new List<Product>()
        {
            new Product(){ ID = 1, Name = "Avatar", Type = "Movie", Price = 30.00 },
            new Product(){ ID = 2, Name = "Shrek", Type = "Movie", Price = 30.00 },
            new Product(){ ID = 3, Name = "The Beatles - Abbey Road", Type = "Music", Price = 25.00 },
            new Product(){ ID = 4, Name = "Bon Jovi - These Days", Type = "Music", Price = 25.00 },
            new Product(){ ID = 5, Name = "Call of Duty", Type = "Game", Price = 60.00 },
            new Product(){ ID = 6, Name = "Elder Scroll - Skyrim", Type = "Game", Price = 60.00 }
        };

        public static int AddProduct(Product product)
        {
            product.ID = Products.Select(p => p.ID).Max() + 1;
            Products.Add(product);
            return product.ID;
        }

        public static Product FetchProductByID(int id) =>
            Products.Where(p => p.ID == id).FirstOrDefault();

    }
}