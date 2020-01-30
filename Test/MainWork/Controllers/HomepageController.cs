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

        public PartialViewResult BasicSerchPartial()
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            var at = db.tAlbumTypes.Select(p => p);
            return PartialView(at);
        }
    }
}