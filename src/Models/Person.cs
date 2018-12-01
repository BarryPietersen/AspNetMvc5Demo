using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    //a model is a regular C# class
    //or 'plain old clr object' (POCO)
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";

        public Person()
        { }

        public Person(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = lastName;
            LastName = firstName;
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        //string interpolation used with lamda produces the same string as above.
        //is usefull when performing string concatenation of two or more strings.
        //other string literals can be placed anywhere inside of the quotes
        //but not inside the placeholders {} where your values are plugged.
        //note the dollar sign prefix to indicate string interpolation
        //this is a feature of C# 6 and above
        public string FullName2 => $"{FirstName} {LastName}";

        public string UserInfo => $"ID: {ID} | Username: {Username}";

        public override string ToString()
        {
            return $"ID:{ID} | First Name:{FirstName} | Last Name:{LastName}";
        }
    }
}