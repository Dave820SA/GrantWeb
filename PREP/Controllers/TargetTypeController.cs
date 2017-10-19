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
    public class TargetTypeController : Controller
    {
        private PrepEntities db = new PrepEntities();

        //
        // GET: /TargetType/

        public ActionResult Index()
        {
            return View(db.TargetTypes.ToList());
        }

        //
        // GET: /TargetType/Details/5

        public ActionResult Details(int id = 0)
        {
            TargetType targettype = db.TargetTypes.Single(t => t.TargetTypeID == id);
            if (targettype == null)
            {
                return HttpNotFound();
            }
            return View(targettype);
        }

        //
        // GET: /TargetType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TargetType/Create

        [HttpPost]
        public ActionResult Create(TargetType targettype)
        {
            if (ModelState.IsValid)
            {
                db.TargetTypes.AddObject(targettype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(targettype);
        }

        //
        // GET: /TargetType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TargetType targettype = db.TargetTypes.Single(t => t.TargetTypeID == id);
            if (targettype == null)
            {
                return HttpNotFound();
            }
            return View(targettype);
        }

        //
        // POST: /TargetType/Edit/5

        [HttpPost]
        public ActionResult Edit(TargetType targettype)
        {
            if (ModelState.IsValid)
            {
                db.TargetTypes.Attach(targettype);
                db.ObjectStateManager.ChangeObjectState(targettype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(targettype);
        }

        //
        // GET: /TargetType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TargetType targettype = db.TargetTypes.Single(t => t.TargetTypeID == id);
            if (targettype == null)
            {
                return HttpNotFound();
            }
            return View(targettype);
        }

        //
        // POST: /TargetType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TargetType targettype = db.TargetTypes.Single(t => t.TargetTypeID == id);
            db.TargetTypes.DeleteObject(targettype);
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