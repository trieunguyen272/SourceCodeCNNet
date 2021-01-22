using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models.Dao;
using DMS_DTCK.Common;
using PagedList;

namespace DMS_DTCK.Areas.Student.Controllers
{
    public class PHONGsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Student/PHONGs
        public ActionResult Index(int page=1, int pagesize =18)
        {
            //var pHONGs = db.PHONGs.Include(p => p.KHUNHA);
            var dao = new UserDao();
            var pHONGs = dao.DanhSach().ToPagedList(page, pagesize);
            return View(pHONGs);
        }

        // GET: Student/PHONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONG pHONG = db.PHONGs.Find(id);
            if (pHONG == null)
            {
                return HttpNotFound();
            }
            var ph = db.PHONGs.SingleOrDefault(x => x.MAPHONG.Equals(id));
            var idSession = new RegistrationRoom();
            idSession.ID = ph.MAPHONG;
            Session.Add(CommonConstants.ID_SESSION, idSession);
            return View(pHONG);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SearchByName (string name)
        {
            List < PHONG > DSTimKiem = db.PHONGs.Where(x => x.MAPHONG.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
