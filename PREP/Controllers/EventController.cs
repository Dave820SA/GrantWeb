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
    public class EventController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View(db.Prep_Event.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            Prep_Event prep_event = db.Prep_Event.Single(p => p.EventID == id);
            if (prep_event == null)
            {
                return HttpNotFound();
            }
            return View(prep_event);
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(Prep_Event prep_event)
        {
            if (ModelState.IsValid)
            {
                db.Prep_Event.AddObject(prep_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prep_event);
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Prep_Event prep_event = db.Prep_Event.Single(p => p.EventID == id);
            if (prep_event == null)
            {
                return HttpNotFound();
            }
            return View(prep_event);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Prep_Event prep_event)
        {
            if (ModelState.IsValid)
            {
                db.Prep_Event.Attach(prep_event);
                db.ObjectStateManager.ChangeObjectState(prep_event, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prep_event);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Prep_Event prep_event = db.Prep_Event.Single(p => p.EventID == id);
            if (prep_event == null)
            {
                return HttpNotFound();
            }
            return View(prep_event);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Prep_Event prep_event = db.Prep_Event.Single(p => p.EventID == id);
            db.Prep_Event.DeleteObject(prep_event);
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