using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWork.Controllers
{
    public class BasicSerchController : Controller
    {
        // GET: BasicSerch
        public ActionResult BasicSerch()
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            var at = db.tAlbumTypes.Select(p => p);
            return View(at);
        }
    }
}