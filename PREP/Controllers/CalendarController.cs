using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PREP.Models;


namespace PREP.Controllers
{
    public class CalendarController : Controller
    {
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetEvents()
        {

            using (SAPDActivityEntities dc = new SAPDActivityEntities())
            {
                var events = dc.Prep_Event.ToList();
                return Json(events, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Prep_Event e)
        {
            var status = false;
            using (SAPDActivityEntities dc = new SAPDActivityEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Prep_Event.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Prep_Event.AddObject(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (SAPDActivityEntities dc = new SAPDActivityEntities())
            {
                var v = dc.Prep_Event.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Prep_Event.DeleteObject(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}
