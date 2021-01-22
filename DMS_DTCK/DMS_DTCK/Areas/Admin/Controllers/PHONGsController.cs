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

namespace DMS_DTCK.Areas.Admin.Controllers
{
    public class PHONGsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/PHONGs
        public ActionResult Index()
        {
            var pHONGs = db.PHONGs.Include(p => p.KHUNHA);
            return View(pHONGs.ToList());
        }

        // GET: Admin/PHONGs/Details/5
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
            return View(pHONG);
        }

        // GET: Admin/PHONGs/Create
        public ActionResult Create()
        {
            ViewBag.MAKHU = new SelectList(db.KHUNHAs, "MAKHU", "TENKHU");
            return View();
        }

        // POST: Admin/PHONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPHONG,SOPHONG,MAKHU,SOLUONGSV,GIAPHONG,SOCHOTRONG,MOTAKHAC,TRANGTHAI")] PHONG pHONG)
        {
            var dao = new AdminDao();
            if (ModelState.IsValid)
            {
                if (dao.insertPhong(pHONG.MAPHONG))
                {
                    db.PHONGs.Add(pHONG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Mã phòng đã tồn tại!");
                }
            }

            ViewBag.MAKHU = new SelectList(db.KHUNHAs, "MAKHU", "TENKHU", pHONG.MAKHU);
            return View(pHONG);
        }

        // GET: Admin/PHONGs/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.MAKHU = new SelectList(db.KHUNHAs, "MAKHU", "TENKHU", pHONG.MAKHU);
            return View(pHONG);
        }

        // POST: Admin/PHONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPHONG,SOPHONG,MAKHU,SOLUONGSV,GIAPHONG,SOCHOTRONG,MOTAKHAC,TRANGTHAI")] PHONG pHONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKHU = new SelectList(db.KHUNHAs, "MAKHU", "TENKHU", pHONG.MAKHU);
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
        public ActionResult SearchByName(string name)
        {
            List<PHONG> DSTimKiem = db.PHONGs.Where(x => x.MAPHONG.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
