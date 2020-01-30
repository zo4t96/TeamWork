using MusicPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicPrj.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        // GET: Common
        public ActionResult Login()
        {
            CWebInitailize ad = new CWebInitailize();
            ViewBag.InitialModel = ad.advancedInitial();
            return View();
        }

        [HttpPost]
        public ActionResult Login(bool ajax)
        {
            CWebInitailize ad = new CWebInitailize();
            ViewBag.InitialModel = ad.advancedInitial();
            return View();
        }
    }
}