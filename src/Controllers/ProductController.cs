using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    //here we have our 'Product'Controller
    //any request urls that contain - www.domain.com/product/{actionmethod} will be directed to this controller for processing.
    public class ProductController : Controller
    {
        //the optional parmeter specified in our route can be seen used here
        //use the url: localhost:{someportnumber}/product/getproduct/{id}
        //the id will be passed into the action method
        public ViewResult GetProduct(int id)
        {
            //talk to database and get back the product with the matchig id
            Product product = Data.FetchProductByID(id);

            if (product == null)
            {
                //we have an issue with the data
                ViewBag.ErrorMessage = "the id supplied matches no results";
                return View("Error");
            }

            return View("ProductResult", product);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(Product product)
        {
            //we have access to the HttpRequestBase
            if (Request["btnSubmit"] == null)
            { }

            //we also have HttpSessionStateBase in
            //the Session Property of the Controller
            string sessionID = Session.SessionID;

            //talk to db and create product record
            product.ID = Data.AddProduct(product);

            if (product.ID == 0)
            {
                //we have an issue with the data
                ViewBag.ErrorMessage = "the create operation failed";
                return View("Error");
            }

            return View("ProductResult", product);
        }

        //because controllers are regular classes we can create methods that do not
        //respond to requests and just have logic we can call at anytime.
        //any method in a controller that is not marked as public will not be recognised
        //by the route engine. the rule applies to all other access modifiers aswell
        private void SpecialControllerMethod()
        {
            //perform any logic you like here
            //and call this method anywhere
            //in your controller
        }

        //if you need a non-routable public method in your controller
        //you can mark it the the [NonAction] attribute tag
        //this method will be ignored by the route engine
        [NonAction]
        public void AnotherMethod()
        {
        }
    }
}