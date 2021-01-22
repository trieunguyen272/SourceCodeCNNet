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
    public class THANNHANsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        
        

        // GET: Student/THANNHANs/Create
        public ActionResult Create()
        {
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "HOVATEN");
            
            return View();
        }

        // POST: Student/THANNHANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATHANNHAN,MASV,HOTENCHA,NGHENGHIEPCHA,SDTCHA,HOTENME,NGHENGHIEPME,SDTME,THANNHANSVNT")] THANNHAN tHANNHAN)
        {
            
            if (ModelState.IsValid)
            {
                tHANNHAN.THANNHANSVNT = true;
                db.THANNHANs.Add(tHANNHAN);
                db.SaveChanges();
                return RedirectToAction("Create", "HOPDONGs", new { Area = "Student" });
            }
            
            ViewBag.MASV = new SelectList(db.SINHVIENs, "MASV", "HOVATEN", tHANNHAN.MASV);
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
    }
}
