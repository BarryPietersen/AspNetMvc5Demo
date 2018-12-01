using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    //here we have our 'Account'Controller
    //any request urls that contain - www.domain.com/Account/{actionmethod} will be directed to this controller for processing.
    //notice the suffix 'Controller' on our controller name, this convention must be followed when we create controllers.
    //our controllers must also derive from the Controller class in order to behave like an MVC controller.
    public class AccountController : Controller
    {
        public ActionResult LoginForm() { return View(); }

        [HttpPost] //this 'Attribute' will ensure the method is only invoked if the requests http verb is 'POST'
        public ActionResult UserProfile(string username = "", string password = "")
        {
            if (username == string.Empty || password == string.Empty)
            {
                //handle the bad data error
                ViewBag.ErrorMessage = "failed to supply details";
                return View("Error");
            }

            //perform authentication and get person data back from db
            Person p = new Person { ID = Data.GetRandomID, Username = username };

            return View("Profile", p);
        }

        public ActionResult UserProfile(Person person) { return View("Profile", person); }
    }
}