using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationDemo.Controllers
{
    public class ArithmeticController : Controller
    {
        // GET: Arithmetic
        public ActionResult Addnos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addnos(int no1, int no2)
        {
            int ans = no1 + no2;
            return Content(ans.ToString());
        }

        public ActionResult SubtractNos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubtractNos(int no1, int no2)
        {
            int ans = no1 - no2;
            return Content(ans.ToString());
        }

        public ActionResult OpenGoogle()
        {

            return RedirectPermanent("https://www.google.com");

        }

    }
}