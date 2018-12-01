using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    //a model is a regular C# class
    //or 'plain old clr object' (POCO)
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        private double price;
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    //raise error
                    price = 0;
                }
                else
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"PID: {ID} | Name: {Name} | Type: {Type} | Price: {string.Format("{0:C}",Price)}";
        }
    }
}