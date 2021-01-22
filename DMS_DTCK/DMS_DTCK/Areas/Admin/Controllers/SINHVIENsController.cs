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
    public class SINHVIENsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/SINHVIENs
        public ActionResult Index()
        {

            return View(db.SINHVIENs.Where(x => x.SVNOITRU == true).ToList());
        }

        // GET: Admin/SINHVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }


        // GET: Admin/SINHVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: Admin/SINHVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASV,MATKHAU,HOTENLOT,TEN,HOVATEN,NGAYSINH,GIOITINH,DIACHI,CMND,SDT,LOP,KHOA,ANH,SVNOITRU")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sINHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sINHVIEN);
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
            List<SINHVIEN> DSTimKiem = db.SINHVIENs.Where(x => x.MASV.Contains(name) || x.HOVATEN.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
