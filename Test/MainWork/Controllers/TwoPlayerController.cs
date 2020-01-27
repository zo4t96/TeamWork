using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWork.Controllers
{
    public class TwoPlayerController : Controller
    {
        // GET: TwoPlayer
        public ActionResult demoPlayer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult demoPlayer(bool ajax)
        {
            if (ajax)
            {
                ViewBag.ajax = true;
            }
            return View();
        }
    }
}