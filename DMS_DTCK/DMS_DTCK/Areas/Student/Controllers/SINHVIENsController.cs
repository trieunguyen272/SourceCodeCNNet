using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace DMS_DTCK.Areas.Student.Controllers
{
    public class SINHVIENsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

       

        // GET: Student/SINHVIENs/Edit/5
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

        // POST: Student/SINHVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASV,MATKHAU,HOTENLOT,TEN,HOVATEN,NGAYSINH,GIOITINH,DIACHI,CMND,SDT,LOP,KHOA,ANH,SVNOITRU")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                sINHVIEN.SVNOITRU = true;
                sINHVIEN.MATKHAU = sINHVIEN.MATKHAU;
                db.Entry(sINHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return RedirectToAction("Create", "THANNHANs", new { Area = "Student" });
            //return View(sINHVIEN);
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
