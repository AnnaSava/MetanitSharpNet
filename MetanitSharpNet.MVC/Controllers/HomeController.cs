using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetanitSharpNet.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string PostData(string sName)
        {
            return "Параметр запроса: " + sName;
        }

        [HttpPost]
        public string PostData2(string sName, int age)
        {
            return "Параметры запроса: " + sName + " " + age.ToString();
        }

        public string GetData(string sName, int age)
        {
            return "Параметры запроса: " + sName + " " + age.ToString();
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