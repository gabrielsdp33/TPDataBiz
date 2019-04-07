using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPDataBizHackathon.Web.Models;
using TPDataBizHackathon.Web.Requests;

namespace TPDataBizHackathon.Web.Controllers
{
    public class TabuaMareController : Controller
    {
        public ActionResult Tabua()
        {
            return View();
        }

        //public JsonResult getTabua()
        //{
        //    TabuaMareAPI tabuaMareApi = new TabuaMareAPI();
        //    List<TabuaMare> tabuaMare = tabuaMareApi.getTabuaMare();

        //    return Json(tabuaMare);
        //}
    }
}