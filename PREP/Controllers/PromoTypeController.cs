using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PREP.Models;

namespace PREP.Controllers
{
    public class PromoTypeController : Controller
    {
        private PrepEntities db = new PrepEntities();

        //
        // GET: /PromoType/

        public ActionResult Index()
        {
            return View(db.PromoTypes.ToList());
        }

        //
        // GET: /PromoType/Details/5

        public ActionResult Details(int id = 0)
        {
            PromoType promotype = db.PromoTypes.Single(p => p.PromoTypeID == id);
            if (promotype == null)
            {
                return HttpNotFound();
            }
            return View(promotype);
        }

        //
        // GET: /PromoType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PromoType/Create

        [HttpPost]
        public ActionResult Create(PromoType promotype)
        {
            if (ModelState.IsValid)
            {
                db.PromoTypes.AddObject(promotype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promotype);
        }

        //
        // GET: /PromoType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PromoType promotype = db.PromoTypes.Single(p => p.PromoTypeID == id);
            if (promotype == null)
            {
                return HttpNotFound();
            }
            return View(promotype);
        }

        //
        // POST: /PromoType/Edit/5

        [HttpPost]
        public ActionResult Edit(PromoType promotype)
        {
            if (ModelState.IsValid)
            {
                db.PromoTypes.Attach(promotype);
                db.ObjectStateManager.ChangeObjectState(promotype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promotype);
        }

        //
        // GET: /PromoType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PromoType promotype = db.PromoTypes.Single(p => p.PromoTypeID == id);
            if (promotype == null)
            {
                return HttpNotFound();
            }
            return View(promotype);
        }

        //
        // POST: /PromoType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoType promotype = db.PromoTypes.Single(p => p.PromoTypeID == id);
            db.PromoTypes.DeleteObject(promotype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}