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
    public class PrepEventController : Controller
    {
        private PrepEntities db = new PrepEntities();

        //
        // GET: /PrepEvent/

        public ActionResult Index()
        {
            return View(db.PrepEvents.ToList());
        }

        //
        // GET: /PrepEvent/Details/5

        public ActionResult Details(int id = 0)
        {
            PrepEvent prepevent = db.PrepEvents.Single(p => p.EventID == id);
            if (prepevent == null)
            {
                return HttpNotFound();
            }
            return View(prepevent);
        }

        //
        // GET: /PrepEvent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PrepEvent/Create

        [HttpPost]
        public ActionResult Create(PrepEvent prepevent)
        {
            if (ModelState.IsValid)
            {
                db.PrepEvents.AddObject(prepevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prepevent);
        }

        //
        // GET: /PrepEvent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PrepEvent prepevent = db.PrepEvents.Single(p => p.EventID == id);
            if (prepevent == null)
            {
                return HttpNotFound();
            }
            return View(prepevent);
        }

        //
        // POST: /PrepEvent/Edit/5

        [HttpPost]
        public ActionResult Edit(PrepEvent prepevent)
        {
            if (ModelState.IsValid)
            {
                db.PrepEvents.Attach(prepevent);
                db.ObjectStateManager.ChangeObjectState(prepevent, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prepevent);
        }

        //
        // GET: /PrepEvent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PrepEvent prepevent = db.PrepEvents.Single(p => p.EventID == id);
            if (prepevent == null)
            {
                return HttpNotFound();
            }
            return View(prepevent);
        }

        //
        // POST: /PrepEvent/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PrepEvent prepevent = db.PrepEvents.Single(p => p.EventID == id);
            db.PrepEvents.DeleteObject(prepevent);
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