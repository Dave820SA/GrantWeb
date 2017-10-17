using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PREP2.Controllers
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
                var events = dc.Events.ToList();
                return Json(events, JsonRequestBehavior.AllowGet);

                
            }
        }

    }
}
