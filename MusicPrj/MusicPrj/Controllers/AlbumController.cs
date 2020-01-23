using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicPrj.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            var album = from a in db.tAlbums
                        select a;
            Session["account"] = "aaa";
            return View(album);
        }

        public ActionResult test()
        {

            return View();
        }

        public ActionResult MyAlbumList(string account)
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            var list = db.tAlbums.Where(p => p.fAccount == account);
            ViewBag.account = account;
            return View(list);
        }

        public ActionResult AlbumInfo(int amid)
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            ViewBag.AlbInfo = db.tAlbums.FirstOrDefault(p => p.fAlbumID == amid);
            var list = db.tProducts.Where(p => p.fAlbumID == amid);
   //         Session["account"] = "aaa";
            if (list != null)
            {
                Session["albumid"] = amid;
                return View(list);
            }
            else
            {
                return View();
            }
        }

        public ActionResult AlbumInfo2(int amid)
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            ViewBag.AlbInfo = db.tAlbums.FirstOrDefault(p => p.fAlbumID == amid);
            var list = db.tProducts.Where(p => p.fAlbumID == amid);
            //         Session["account"] = "aaa";
            if (list != null)
            {
                Session["albumid"] = amid;
                return View(list);
            }
            else
            {
                return View();
            }
        }

        public ActionResult AlbumDetail(int amid)
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            ViewBag.AlbInfo = db.tAlbums.FirstOrDefault(p => p.fAlbumID == amid);
            var list = db.tProducts.Where(p => p.fAlbumID == amid);
            //         Session["account"] = "aaa";
            if (list != null)
            {
                Session["albumid"] = amid;
                return View(list);
            }
            else
            {
                return View();
            }
        }

        public ActionResult AlbumInfo3()
        {
            return View(new tProduct());
        }

        public ActionResult AlbumInfo4()
        {
            tProduct prod = (new dbProjectMusicStoreEntities()).tProducts.FirstOrDefault(p => p.fProductID == 2);
            if (prod == null)
                return RedirectToAction("MyAlbumList");
            return View(prod);
        }

        public ActionResult AddAlbum(string account)
        {
            tAlbum tA = new tAlbum();
            tA.fAccount = account;
            
            return View(tA);
        }

        [HttpPost]
        public ActionResult AddAlbum(tAlbum tA)
        {
            string name = Guid.NewGuid().ToString() + ".jpg";
            var path = Path.Combine(Server.MapPath("~/CoverFiles/"), name);
            tA.fCoverPath = name;
            tA.fCoverRealFile.SaveAs(path);
            tA.fAccount = Session["account"].ToString();
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            db.tAlbums.Add(tA);
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
               ViewBag.error=  ex.Message.ToString();
            }
       //     return View();
                   return Redirect("MyAlbumList");
        }

        //上傳單曲
        [HttpPost]
        public ActionResult AlbumInfo(tProduct tP)
        {
            if(tP == null)
            {
                return View();
            }
            string name = Guid.NewGuid().ToString() + ".mp3";
            var path = Path.Combine(Server.MapPath("~/MusicFiles/"), name);
            tP.fFilePath = name;
            tP.fRealFile.SaveAs(path);
            tP.fStatus = 1;
            tP.fAlbumID = Int32.Parse(Session["albumid"].ToString());
            tP.fPlayStart = Convert.ToDouble(tP.fPlays);
            tP.fPlayEnd = Convert.ToDouble(tP.fPlaye);
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            db.tProducts.Add(tP);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString();
            }

            string s1 = "AlbumInfo?amid=" + Session["albumid"].ToString();
            return Redirect(s1);
        }



        //編輯單曲
        public ActionResult EditSong(int amid)
        {
            return View();
        }


        //刪除單曲
        public ActionResult DelteSong(int amid)
        {
            string s1 = "AlbumInfo?amid=" + Session["albumid"].ToString();
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            tProduct tP = db.tProducts.FirstOrDefault(p=>p.fProductID == amid);
            if (tP == null)
            {
                return Redirect(s1);
            }

            db.tProducts.Remove(tP);
            try
            {
                db.SaveChanges();
                string fileName = tP.fFilePath;
                var path = Path.Combine(Server.MapPath("~/MusicFiles/"), fileName);
                // Delete the file if it exists.
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    ViewBag.Msg = "檔案不存在或在使用中";
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString();
                return View();
            }
            return Redirect(s1);
        }

        public ActionResult DeleteAlbum(int amid)
        {
            string s1 = "MyAlbumList?amid=" + Session["account"].ToString();
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            tAlbum tA = db.tAlbums.FirstOrDefault(p => p.fAlbumID == amid);
            if (tA == null)
            {
                return Redirect(s1);
            }
            List<tProduct> tP = db.tProducts.Where(p => p.fAlbumID == amid).ToList();
            if (tP == null)
            {
                return Redirect(s1);
            }
            var Coverpath = Path.Combine(Server.MapPath("~/CoverFiles/"), tA.fCoverPath);
            if (System.IO.File.Exists(Coverpath))
            {
                System.IO.File.Delete(Coverpath);
            }
            else
            {
                ViewBag.Msg = "檔案不存在或在使用中";
            }
            foreach (var prod in tP)
            {
                var path = Path.Combine(Server.MapPath("~/MusicFiles/"), prod.fFilePath);
                // Delete the file if it exists.
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    ViewBag.Msg = "檔案不存在或在使用中";
                }
            }
            db.tProducts.RemoveRange(tP);
            db.tAlbums.Remove(tA);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString();
                return View();
            }
            return Redirect(s1);
        }

        //更新單曲
        public ActionResult updateSongTryLimit(int amid, float start, float end)
        {
      //      return View();
            string s1 = "AlbumInfo?amid=" + Session["albumid"].ToString();
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            tProduct tP = db.tProducts.FirstOrDefault(p => p.fProductID == amid);
            string s2 = "";
            if (tP == null)
            {
                //          return Redirect(s1);
                s2 = "失敗";
                return Json(s2);
            }
            tP.fPlayStart = start;
            tP.fPlayEnd = end;
            db.SaveChanges();
            s2 = "成功";
                return Json(s2);
        }

        public ActionResult updateSongTryLimit2(int amid, float start, float end)
        {
            //      return View();
            string s1 = "AlbumInfo?amid=" + Session["albumid"].ToString();
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            tProduct tP = db.tProducts.FirstOrDefault(p => p.fProductID == amid);
            string s2 = "";
            if (tP == null)
            {
                //          return Redirect(s1);
                s2 = "失敗";
                return Json(s2);
            }
            tP.fPlayStart = start;
            tP.fPlayEnd = end;
            db.SaveChanges();
            s2 = "成功";
            return Json(s2);
        }
    }
}