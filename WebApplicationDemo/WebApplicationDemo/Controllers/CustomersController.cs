using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationDemo.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Login()
        {
            return Content("This is the login page");
            //return View();
        }
    }
}