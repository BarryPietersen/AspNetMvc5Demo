using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    //here we have our 'Home'Controller
    //any request urls that contain - www.domain.com/Home/{actionmethod} will be directed to this controller for processing.
    //notice the suffix 'Controller' on our controller name, this convention must be followed when we create controllers.
    //our controllers must also derive from the Controller class in order to behave like an MVC controller.
    public class HomeController : Controller
    {
        //this action method will do nothing other than return an ActionResult.
        //first the View() method will be invoked with a string value that is 
        //the file name of the view to be rendered and returned.
        //note the file extension .cshtml is omitted.
        public ActionResult Index()
        {
            return View("Index");
        }

        //invoke an action method with no parameters
        //and a return type of ViewResult
        public ViewResult About()
        {
            //note we are not passing any parameters to
            //the View() method on the Controller base class.
            //MVC will now attempt to return a view with a file name
            //that matches the Action Method name 'About' or 'about'
            //and will start by looking in the Views/Home folder
            return View();
        }

        //paste the text localhost:{someportnumber}/Home/ProcessPersonData?id=1&firstname=myfirstname&lastname=mylastname
        //into your browsers url to observe the MVC model binder in action

        //MVC model binding provides a convenient way to pass data from the request to the action method.
        //before this action method is invoked an MVC model binder will observe request data and
        //take its 'best shot' at instantiating a Person based on the property names defined in Person
        //and the field names in the request.
        //a few things to consider when using this feature
        //- constructor methods and valid object state
        //custom model binding is also an option - https://mono.software/2017/02/09/model-binding-asp-net-mvc/
        public string ProcessPersonData(Person person)
        {
            return person.ToString();
        }
    }
}