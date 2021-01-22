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
    public class DGDIENsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/DGDIENs
        public ActionResult Index()
        {
            return View(db.DGDIENs.ToList());
        }

        // GET: Admin/DGDIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGDIEN dGDIEN = db.DGDIENs.Find(id);
            if (dGDIEN == null)
            {
                return HttpNotFound();
            }
            return View(dGDIEN);
        }

        // GET: Admin/DGDIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DGDIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADGDIEN,DONGIADIEN")] DGDIEN dGDIEN)
        {
            if (ModelState.IsValid)
            {
                db.DGDIENs.Add(dGDIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dGDIEN);
        }

        // GET: Admin/DGDIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGDIEN dGDIEN = db.DGDIENs.Find(id);
            if (dGDIEN == null)
            {
                return HttpNotFound();
            }
            return View(dGDIEN);
        }

        // POST: Admin/DGDIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADGDIEN,DONGIADIEN")] DGDIEN dGDIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dGDIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dGDIEN);
        }

        // GET: Admin/DGDIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGDIEN dGDIEN = db.DGDIENs.Find(id);
            if (dGDIEN == null)
            {
                return HttpNotFound();
            }
            return View(dGDIEN);
        }

        // POST: Admin/DGDIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DGDIEN dGDIEN = db.DGDIENs.Find(id);
            db.DGDIENs.Remove(dGDIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
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
