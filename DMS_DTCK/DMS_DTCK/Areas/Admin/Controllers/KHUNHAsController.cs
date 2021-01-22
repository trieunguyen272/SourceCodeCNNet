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
    public class KHUNHAsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: Admin/KHUNHAs
        public ActionResult Index()
        {
            return View(db.KHUNHAs.ToList());
        }

        // GET: Admin/KHUNHAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUNHA kHUNHA = db.KHUNHAs.Find(id);
            if (kHUNHA == null)
            {
                return HttpNotFound();
            }
            return View(kHUNHA);
        }

        // GET: Admin/KHUNHAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KHUNHAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKHU,TENKHU,MOTAKHAC")] KHUNHA kHUNHA)
        {
            var dao = new AdminDao();
            if (ModelState.IsValid)
            {
                if (dao.insertKhuNha(kHUNHA.MAKHU))
                {
                    db.KHUNHAs.Add(kHUNHA);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Mã khu nhà đã tồn tại!");
                }
            }

            return View(kHUNHA);
        }

        // GET: Admin/KHUNHAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUNHA kHUNHA = db.KHUNHAs.Find(id);
            if (kHUNHA == null)
            {
                return HttpNotFound();
            }
            return View(kHUNHA);
        }

        // POST: Admin/KHUNHAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKHU,TENKHU,MOTAKHAC")] KHUNHA kHUNHA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHUNHA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHUNHA);
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
            List<KHUNHA> DSTimKiem = db.KHUNHAs.Where(x => x.MAKHU.Contains(name)).ToList();
            return View(DSTimKiem);
        }
    }
}
