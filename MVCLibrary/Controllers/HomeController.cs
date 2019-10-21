using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logined(string UserName, string Password)
        {
            if(UserName=="Admin" && Password=="1234")
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Login");
        }
    }
}
