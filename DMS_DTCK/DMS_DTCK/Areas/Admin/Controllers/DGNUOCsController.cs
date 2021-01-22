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
    public class DGNUOCsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/DGNUOCs
        public ActionResult Index()
        {
            return View(db.DGNUOCs.ToList());
        }

        // GET: Admin/DGNUOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGNUOC dGNUOC = db.DGNUOCs.Find(id);
            if (dGNUOC == null)
            {
                return HttpNotFound();
            }
            return View(dGNUOC);
        }

        // GET: Admin/DGNUOCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DGNUOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADGNUOC,DONGIANUOC")] DGNUOC dGNUOC)
        {
            if (ModelState.IsValid)
            {
                db.DGNUOCs.Add(dGNUOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dGNUOC);
        }

        // GET: Admin/DGNUOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGNUOC dGNUOC = db.DGNUOCs.Find(id);
            if (dGNUOC == null)
            {
                return HttpNotFound();
            }
            return View(dGNUOC);
        }

        // POST: Admin/DGNUOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADGNUOC,DONGIANUOC")] DGNUOC dGNUOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dGNUOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dGNUOC);
        }

        // GET: Admin/DGNUOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGNUOC dGNUOC = db.DGNUOCs.Find(id);
            if (dGNUOC == null)
            {
                return HttpNotFound();
            }
            return View(dGNUOC);
        }

        // POST: Admin/DGNUOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DGNUOC dGNUOC = db.DGNUOCs.Find(id);
            db.DGNUOCs.Remove(dGNUOC);
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
