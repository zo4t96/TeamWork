﻿using MainWork.Models;
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
            CWebInitailize ad = new CWebInitailize();
            ViewBag.InitialModel = ad.advancedInitial();
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