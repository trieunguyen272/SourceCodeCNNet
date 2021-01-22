using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace DMS_DTCK.Areas.Boarder.Controllers
{
    public class HDDIENNUOCsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        
        // GET: Boarder/HDDIENNUOCs
        public ActionResult Index()
        {
            var session = (DMS_DTCK.Common.RegistrationRoom)Session[DMS_DTCK.Common.CommonConstants.ID_SESSION];
            var idsession = (DMS_DTCK.Common.BoarderLogin)Session[DMS_DTCK.Common.CommonBoarder.BOARDER_SESSION];
            var hDDIENNUOCs = db.HDDIENNUOCs.Include(h => h.DGDIEN).Include(h => h.DGNUOC).Include(h => h.PHONG).Include(h => h.QUANLY);
            return View(hDDIENNUOCs.Where(x => (x.MAPHONG == idsession.IDPhong)).ToList());
        }
        public ActionResult IndexID(string id)
        {
            var session = (DMS_DTCK.Common.RegistrationRoom)Session[DMS_DTCK.Common.CommonConstants.ID_SESSION];
            
            var hDDIENNUOCs = db.HDDIENNUOCs.Include(h => h.DGDIEN).Include(h => h.DGNUOC).Include(h => h.PHONG).Include(h => h.QUANLY);
            return View(hDDIENNUOCs.Where(x => (x.MAPHONG == id)).ToList());
        }
        // GET: Boarder/HDDIENNUOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDDIENNUOC hDDIENNUOC = db.HDDIENNUOCs.Find(id);
            if (hDDIENNUOC == null)
            {
                return HttpNotFound();
            }
            return View(hDDIENNUOC);
        }

        // GET: Boarder/HDDIENNUOCs/Create
        public ActionResult Create()
        {
            ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "MADGDIEN");
            ViewBag.MADGNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "MADGNUOC");
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU");
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MATKHAU");
            return View();
        }

        // POST: Boarder/HDDIENNUOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHOADON,MAPHONG,MAQL,THANG,NAM,CHISODIENCU,CHISODIENMOI,MADGDIEN,TIENDIEN,CHISONUOCCU,CHISONUOCMOI,MADGNUOC,TIENNUOC,TONGTIEN,TRANGTHAITHANHTOAN")] HDDIENNUOC hDDIENNUOC)
        {
            if (ModelState.IsValid)
            {
                db.HDDIENNUOCs.Add(hDDIENNUOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "MADGDIEN", hDDIENNUOC.MADGDIEN);
            ViewBag.MADGNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "MADGNUOC", hDDIENNUOC.MADGNUOC);
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU", hDDIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MATKHAU", hDDIENNUOC.MAQL);
            return View(hDDIENNUOC);
        }

        // GET: Boarder/HDDIENNUOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDDIENNUOC hDDIENNUOC = db.HDDIENNUOCs.Find(id);
            if (hDDIENNUOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "MADGDIEN", hDDIENNUOC.MADGDIEN);
            ViewBag.MADGNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "MADGNUOC", hDDIENNUOC.MADGNUOC);
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU", hDDIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MATKHAU", hDDIENNUOC.MAQL);
            return View(hDDIENNUOC);
        }

        // POST: Boarder/HDDIENNUOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHOADON,MAPHONG,MAQL,THANG,NAM,CHISODIENCU,CHISODIENMOI,MADGDIEN,TIENDIEN,CHISONUOCCU,CHISONUOCMOI,MADGNUOC,TIENNUOC,TONGTIEN,TRANGTHAITHANHTOAN")] HDDIENNUOC hDDIENNUOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDDIENNUOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "MADGDIEN", hDDIENNUOC.MADGDIEN);
            ViewBag.MADGNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "MADGNUOC", hDDIENNUOC.MADGNUOC);
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAKHU", hDDIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MATKHAU", hDDIENNUOC.MAQL);
            return View(hDDIENNUOC);
        }

        // GET: Boarder/HDDIENNUOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDDIENNUOC hDDIENNUOC = db.HDDIENNUOCs.Find(id);
            if (hDDIENNUOC == null)
            {
                return HttpNotFound();
            }
            return View(hDDIENNUOC);
        }

        // POST: Boarder/HDDIENNUOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HDDIENNUOC hDDIENNUOC = db.HDDIENNUOCs.Find(id);
            db.HDDIENNUOCs.Remove(hDDIENNUOC);
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
