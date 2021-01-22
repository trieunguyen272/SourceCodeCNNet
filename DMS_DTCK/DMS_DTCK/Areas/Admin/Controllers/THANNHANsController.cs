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
    public class THANNHANsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/THANNHANs
        public ActionResult Index()
        {
            var tHANNHANs = db.THANNHANs.Include(t => t.SINHVIEN).Where(x => x.THANNHANSVNT == true);
            return View(tHANNHANs.ToList());
        }

        // GET: Admin/THANNHANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANNHAN tHANNHAN = db.THANNHANs.Find(id);
            if (tHANNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANNHAN);
        }

        
        // GET: Admin/THANNHANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANNHAN tHANNHAN = db.THANNHANs.Find(id);
            if (tHANNHAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "MASV", tHANNHAN.MASV);
            return View(tHANNHAN);
        }

        // POST: Admin/THANNHANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATHANNHAN,MASV,HOTENCHA,NGHENGHIEPCHA,SDTCHA,HOTENME,NGHENGHIEPME,SDTME,THANNHANSVNT")] THANNHAN tHANNHAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANNHAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "MASV", tHANNHAN.MASV);
            return View(tHANNHAN);
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
            List<THANNHAN> DSTimKiem = db.THANNHANs.Where(x => x.MASV.Contains(name) || x.HOTENCHA.Contains(name) || x.HOTENME.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
