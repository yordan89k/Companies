using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompaniesYK.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // -- One day ... can add ViewModel to show list of companies, count of Stores and other usefull data at the home page --
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}