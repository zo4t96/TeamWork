using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWork.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        
        public ActionResult homepage()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}