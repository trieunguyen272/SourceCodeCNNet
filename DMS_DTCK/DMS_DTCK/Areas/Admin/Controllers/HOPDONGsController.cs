using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace DMS_DTCK.Areas.Admin.Controllers
{
    public class HOPDONGsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/HOPDONGs
        public ActionResult Index()
        {
            var hOPDONGs = db.HOPDONGs.Include(h => h.PHONG).Include(h => h.SINHVIEN).Where(x => x.HIEULUCHD == true);
            return View(hOPDONGs.ToList());
        }

        // GET: Admin/HOPDONGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

       

        // GET: Admin/HOPDONGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU", hOPDONG.MAPHONG);
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "MATKHAU", hOPDONG.MASV);
            return View(hOPDONG);
        }

        // POST: Admin/HOPDONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHOPDONG,MASV,MAPHONG,NGAYLAP,NGAYBATDAU,NGAYKETTHUC,HIEULUCHD")] HOPDONG hOPDONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOPDONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult SearchByName(string name)
        {
            List<HOPDONG> DSTimKiem = db.HOPDONGs.Where(x => x.MASV.Contains(name) || x.MAPHONG.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
