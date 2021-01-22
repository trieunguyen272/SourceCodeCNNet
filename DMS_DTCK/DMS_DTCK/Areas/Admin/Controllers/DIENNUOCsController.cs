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
    public class DIENNUOCsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/DIENNUOCs
        public ActionResult Index()
        {
            var dIENNUOCs = db.DIENNUOCs.Include(d => d.PHONG).Include(d => d.QUANLY);
            return View(dIENNUOCs.ToList());
        }

        // GET: Admin/DIENNUOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENNUOC dIENNUOC = db.DIENNUOCs.Find(id);
            if (dIENNUOC == null)
            {
                return HttpNotFound();
            }
            return View(dIENNUOC);
        }

        // GET: Admin/DIENNUOCs/Create
        public ActionResult Create()
        {
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG");
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL");
            return View();
        }

        // POST: Admin/DIENNUOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADIENNUOC,MAPHONG,MAQL,THANG,NAM,CHISODIEN,CHISONUOC")] DIENNUOC dIENNUOC)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                
                if (dao.InsertDienNuoc(dIENNUOC.MAPHONG, dIENNUOC.THANG, dIENNUOC.NAM))
                {
                    if (dIENNUOC.THANG >1)
                    {
                        if (dao.InsertDienNuoc(dIENNUOC.MAPHONG, dIENNUOC.THANG-1, dIENNUOC.NAM))
                        {
                            db.DIENNUOCs.Add(dIENNUOC);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            int sodiencu = dao.LaySoDien(dIENNUOC.MAPHONG, dIENNUOC.THANG - 1, dIENNUOC.NAM);
                            int sonuoccu = dao.LaySoNuoc(dIENNUOC.MAPHONG, dIENNUOC.THANG - 1, dIENNUOC.NAM);
                            if (sodiencu < dIENNUOC.CHISODIEN && sonuoccu < dIENNUOC.CHISONUOC)
                            {
                                db.DIENNUOCs.Add(dIENNUOC);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                if (sodiencu > dIENNUOC.CHISODIEN)
                                {
                                    ModelState.AddModelError("", "Chỉ số điện phải lớn hơn tháng trước!");
                                }
                                if (sonuoccu > dIENNUOC.CHISONUOC)
                                {
                                    ModelState.AddModelError("", "Chỉ số nước phải lớn hơn tháng trước!");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dao.InsertDienNuoc(dIENNUOC.MAPHONG, 12, dIENNUOC.NAM -1))
                        {
                            db.DIENNUOCs.Add(dIENNUOC);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            int sodiencu = dao.LaySoDien(dIENNUOC.MAPHONG, 12, dIENNUOC.NAM - 1);
                            int sonuoccu = dao.LaySoNuoc(dIENNUOC.MAPHONG, 12, dIENNUOC.NAM - 1);
                            if (sodiencu < dIENNUOC.CHISODIEN && sonuoccu < dIENNUOC.CHISONUOC)
                            {
                                db.DIENNUOCs.Add(dIENNUOC);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                if (sodiencu > dIENNUOC.CHISODIEN)
                                {
                                    ModelState.AddModelError("", "Chỉ số điện phải lớn hơn tháng trước!");
                                }
                                if (sonuoccu > dIENNUOC.CHISONUOC)
                                {
                                    ModelState.AddModelError("", "Chỉ số nước phải lớn hơn tháng trước!");
                                }
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Phòng này đã được thêm!");
                }
            }
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", dIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", dIENNUOC.MAQL);
            return View(dIENNUOC);
        }

        // GET: Admin/DIENNUOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENNUOC dIENNUOC = db.DIENNUOCs.Find(id);
            if (dIENNUOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", dIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", dIENNUOC.MAQL);
            return View(dIENNUOC);
        }

        // POST: Admin/DIENNUOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADIENNUOC,MAPHONG,MAQL,THANG,NAM,CHISODIEN,CHISONUOC")] DIENNUOC dIENNUOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIENNUOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAPHONG = new SelectList(db.PHONGs, "MAPHONG", "MAPHONG", dIENNUOC.MAPHONG);
            ViewBag.MAQL = new SelectList(db.QUANLies, "MAQL", "MAQL", dIENNUOC.MAQL);
            return View(dIENNUOC);
        }

        // GET: Admin/DIENNUOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENNUOC dIENNUOC = db.DIENNUOCs.Find(id);
            if (dIENNUOC == null)
            {
                return HttpNotFound();
            }
            return View(dIENNUOC);
        }

        // POST: Admin/DIENNUOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIENNUOC dIENNUOC = db.DIENNUOCs.Find(id);
            db.DIENNUOCs.Remove(dIENNUOC);
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
            List<DIENNUOC> DSTimKiem = db.DIENNUOCs.Where(x => x.MAPHONG.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
