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
    public class AssetTypeController : Controller
    {
        private PrepEntities db = new PrepEntities();

        //
        // GET: /AssetType/

        public ActionResult Index()
        {
            return View(db.AssetTypes.ToList());
        }

        //
        // GET: /AssetType/Details/5

        public ActionResult Details(int id = 0)
        {
            AssetType assettype = db.AssetTypes.Single(a => a.AssetTypeID == id);
            if (assettype == null)
            {
                return HttpNotFound();
            }
            return View(assettype);
        }

        //
        // GET: /AssetType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AssetType/Create

        [HttpPost]
        public ActionResult Create(AssetType assettype)
        {
            if (ModelState.IsValid)
            {
                db.AssetTypes.AddObject(assettype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assettype);
        }

        //
        // GET: /AssetType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AssetType assettype = db.AssetTypes.Single(a => a.AssetTypeID == id);
            if (assettype == null)
            {
                return HttpNotFound();
            }
            return View(assettype);
        }

        //
        // POST: /AssetType/Edit/5

        [HttpPost]
        public ActionResult Edit(AssetType assettype)
        {
            if (ModelState.IsValid)
            {
                db.AssetTypes.Attach(assettype);
                db.ObjectStateManager.ChangeObjectState(assettype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assettype);
        }

        //
        // GET: /AssetType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AssetType assettype = db.AssetTypes.Single(a => a.AssetTypeID == id);
            if (assettype == null)
            {
                return HttpNotFound();
            }
            return View(assettype);
        }

        //
        // POST: /AssetType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetType assettype = db.AssetTypes.Single(a => a.AssetTypeID == id);
            db.AssetTypes.DeleteObject(assettype);
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