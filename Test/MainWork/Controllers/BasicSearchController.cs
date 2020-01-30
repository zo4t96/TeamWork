using MainWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWork.Controllers
{
    public class BasicSearchController : Controller
    {
        // GET: BasicSearch
        public ActionResult BasicSearch()
        {
            CWebInitailize ad = new CWebInitailize();
            ViewBag.InitialModel = ad.advancedInitial();
            CTakeKind tk = new CTakeKind();
            return View(tk.takeAllKind());
        }

        [HttpPost]
        public ActionResult BasicSearch(bool ajax)
        {
            CTakeKind tk = new CTakeKind();
            if (ajax)
            {
                ViewBag.ajax = true;
            }
            return View(tk.takeAllKind());
        }
    }
}