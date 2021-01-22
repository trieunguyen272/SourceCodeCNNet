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

namespace DMS_DTCK.Areas.Student.Controllers
{
    public class HOPDONGsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        

        // GET: Student/HOPDONGs/Create
        public ActionResult Create()
        {
            HOPDONG hd = new HOPDONG();
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU");
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "MATKHAU");
            
            return View();
        }

        // POST: Student/HOPDONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHOPDONG,MASV,MAPHONG,NGAYLAP,NGAYBATDAU,NGAYKETTHUC,HIEULUCHD")] HOPDONG hOPDONG)
        {
            
            var idsession = (DMS_DTCK.Common.RegistrationRoom)Session[DMS_DTCK.Common.CommonConstants.ID_SESSION];
           
            if (ModelState.IsValid)
            {
                hOPDONG.HIEULUCHD = true;
                hOPDONG.NGAYLAP = DateTime.Now;
                db.HOPDONGs.Add(hOPDONG);
                db.SaveChanges();
                var dao = new StudentDao();
                dao.UpdateSoChoTrong(idsession.ID);
                return RedirectToAction("IndexID", "HDDIENNUOCs", new { Area = "Boarder", id= idsession.ID});
                //return RedirectToAction("Index");
            }

            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU", hOPDONG.MAPHONG);
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "MATKHAU", hOPDONG.MASV);
            return View(hOPDONG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
