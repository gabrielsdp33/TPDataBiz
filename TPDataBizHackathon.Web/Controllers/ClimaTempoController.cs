using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPDataBizHackathon.Web.Models;
using TPDataBizHackathon.Web.Requests;

namespace TPDataBizHackathon.Web.Controllers
{
    public class ClimaTempoController : Controller
    {
        // GET: ClimaTempo
        public ActionResult Semana()
        {
            string diaSemana = DateTime.Now.ToString("dddd", new CultureInfo("pt-BR"));
            ViewBag.diaSemana = diaSemana.First().ToString().ToUpper() + diaSemana.Substring(1).ToString();

            return View();
        }

        public JsonResult getWeek()
        {
            ClimaTempoAPI climaTempoAPI = new ClimaTempoAPI();
            List<ClimaTempo> result = climaTempoAPI.getWeek();

            return Json(result);
        }
    }
}