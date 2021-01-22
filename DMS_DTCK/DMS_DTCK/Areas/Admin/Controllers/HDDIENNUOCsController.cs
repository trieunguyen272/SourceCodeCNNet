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
    public class HDDIENNUOCsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/HDDIENNUOCs
        public ActionResult Index()
        {
            var hDDIENNUOCs = db.HDDIENNUOCs.Include(h => h.DGDIEN).Include(h => h.DGNUOC).Include(h => h.PHONG).Include(h => h.QUANLY);
            return View(hDDIENNUOCs.ToList());
        }

        // GET: Admin/HDDIENNUOCs/Details/5
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

        // GET: Admin/HDDIENNUOCs/Create
        public ActionResult Create()
        {
            ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "DONGIADIEN");
            ViewBag.MADGNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "DONGIANUOC");
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG");
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL");
            return View();
        }

        // POST: Admin/HDDIENNUOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "THANG,NAM,MADGDIEN,MADGNUOC")] HDDIENNUOC hDDIENNUOC)
        {
            var dao = new AdminDao();
            var session = (DMS_DTCK.Common.AdminLogin)Session[DMS_DTCK.Common.CommonAdmin.ADMIN_SESSION];
            List<DIENNUOC> phongmoi = db.DIENNUOCs.Where(x => (x.THANG.Equals(hDDIENNUOC.THANG))
                            && (x.NAM.Equals(hDDIENNUOC.NAM))).ToList();
            var dgdien = db.DGDIENs.Find(hDDIENNUOC.MADGDIEN);
            var dgnuoc = db.DGNUOCs.Find(hDDIENNUOC.MADGNUOC);
            if ((dao.InsertHDDN(hDDIENNUOC.THANG, hDDIENNUOC.NAM)) == true)
            {
                foreach (var item in phongmoi)
                {
                    string mp = item.MAPHONG;
                    var phongcu = item;
                    if (hDDIENNUOC.THANG > 1)
                    {
                        if ((dao.InsertDienNuoc(item.MAPHONG, hDDIENNUOC.THANG - 1, hDDIENNUOC.NAM)))
                        {
                            continue;
                        }
                    else
                    {
                        phongcu = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(hDDIENNUOC.THANG - 1))
                                        && (x.NAM.Equals(hDDIENNUOC.NAM))).SingleOrDefault();
                    } 
                    }
                    else
                    {
                        if (dao.InsertDienNuoc(item.MAPHONG, 12, hDDIENNUOC.NAM - 1))
                        {
                            continue;
                        }
                        else
                        {
                            phongcu = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(12))
                                    && (x.NAM.Equals(hDDIENNUOC.NAM - 1))).SingleOrDefault();
                        }
                    }
                    hDDIENNUOC.MAPHONG = item.MAPHONG;
                    hDDIENNUOC.MAQL = session.UserName;
                    hDDIENNUOC.THANG = hDDIENNUOC.THANG;
                    hDDIENNUOC.NAM = hDDIENNUOC.NAM;
                    hDDIENNUOC.CHISODIENMOI = item.CHISODIEN;
                    hDDIENNUOC.CHISODIENCU = phongcu.CHISODIEN;
                    hDDIENNUOC.TIENDIEN = (hDDIENNUOC.CHISODIENMOI - hDDIENNUOC.CHISODIENCU) * dgdien.DONGIADIEN;
                    hDDIENNUOC.CHISONUOCMOI = item.CHISONUOC;
                    hDDIENNUOC.CHISONUOCCU = phongcu.CHISONUOC;
                    hDDIENNUOC.TIENNUOC = (hDDIENNUOC.CHISONUOCMOI - hDDIENNUOC.CHISONUOCCU) * dgnuoc.DONGIANUOC;
                    hDDIENNUOC.TONGTIEN = hDDIENNUOC.TIENDIEN + hDDIENNUOC.TIENNUOC;
                    hDDIENNUOC.TRANGTHAITHANHTOAN = false;
                    if (ModelState.IsValid)
                    {
                        db.HDDIENNUOCs.Add(hDDIENNUOC);
                        db.SaveChanges();
                     }
                     ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "DONGIADIEN", hDDIENNUOC.MADGDIEN);
                     ViewBag.MADGDNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "DONGIANUOC", hDDIENNUOC.MADGNUOC);
                     ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", hDDIENNUOC.MAPHONG);
                     ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", hDDIENNUOC.MAQL);
                }
            }
            if ((dao.InsertHDDN(hDDIENNUOC.THANG, hDDIENNUOC.NAM)) == false)
            {
                foreach (var item in phongmoi)
                {
                    if (dao.InsertHDDienNuoc(item.MAPHONG, hDDIENNUOC.THANG, hDDIENNUOC.NAM))
                    {
                        string mp = item.MAPHONG;
                        var phongcu = item;
                        if (hDDIENNUOC.THANG > 1)
                        {
                            if ((dao.InsertDienNuoc(item.MAPHONG, hDDIENNUOC.THANG - 1, hDDIENNUOC.NAM)))
                            {
                                continue;
                            }
                            else
                            {
                                phongcu = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(hDDIENNUOC.THANG - 1))).SingleOrDefault();
                            }
                        }
                        else
                        {
                            if (dao.InsertDienNuoc(item.MAPHONG, 12, hDDIENNUOC.NAM - 1))
                            {
                                continue;
                            }
                            else
                            { 
                                phongcu = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(12))
                                    && (x.NAM.Equals(hDDIENNUOC.NAM - 1))).SingleOrDefault();
                            }
                        }
                        hDDIENNUOC.MAPHONG = item.MAPHONG;
                        hDDIENNUOC.MAQL = session.UserName;
                        hDDIENNUOC.THANG = hDDIENNUOC.THANG;
                        hDDIENNUOC.NAM = hDDIENNUOC.NAM;
                        hDDIENNUOC.CHISODIENMOI = item.CHISODIEN;
                        hDDIENNUOC.CHISODIENCU = phongcu.CHISODIEN;
                        hDDIENNUOC.TIENDIEN = (hDDIENNUOC.CHISODIENMOI - hDDIENNUOC.CHISODIENCU) * dgdien.DONGIADIEN;
                        hDDIENNUOC.CHISONUOCMOI = item.CHISONUOC;
                        hDDIENNUOC.CHISONUOCCU = phongcu.CHISONUOC;
                        hDDIENNUOC.TIENNUOC = (hDDIENNUOC.CHISONUOCMOI - hDDIENNUOC.CHISONUOCCU) * dgnuoc.DONGIANUOC;
                        hDDIENNUOC.TONGTIEN = hDDIENNUOC.TIENDIEN + hDDIENNUOC.TIENNUOC;
                        hDDIENNUOC.TRANGTHAITHANHTOAN = false;
                        if (ModelState.IsValid)
                        {
                            db.HDDIENNUOCs.Add(hDDIENNUOC);
                            db.SaveChanges();
                        }
                        ViewBag.MADGDIEN = new SelectList(db.DGDIENs, "MADGDIEN", "DONGIADIEN", hDDIENNUOC.MADGDIEN);
                        ViewBag.MADGDNUOC = new SelectList(db.DGNUOCs, "MADGNUOC", "DONGIANUOC", hDDIENNUOC.MADGNUOC);
                        ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", hDDIENNUOC.MAPHONG);
                        ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", hDDIENNUOC.MAQL);
                    }
                }
            }
            return RedirectToAction("Index");
        }


        // GET: Admin/HDDIENNUOCs/Edit/5
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
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", hDDIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", hDDIENNUOC.MAQL);
            return View(hDDIENNUOC);
        }

        // POST: Admin/HDDIENNUOCs/Edit/5
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
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", hDDIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", hDDIENNUOC.MAQL);
            return View(hDDIENNUOC);
        }

        // GET: Admin/HDDIENNUOCs/Delete/5
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

        // POST: Admin/HDDIENNUOCs/Delete/5
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
        public ActionResult SearchByName(string name)
        {
            List<HDDIENNUOC> DSTimKiem = db.HDDIENNUOCs.Where(x => x.MAPHONG.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
