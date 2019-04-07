using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TPDataBizHackathon.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> GetClimate(string url, string )
        //{
        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.PostAsync("/climate");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsondata = await response.Content.ReadAsStringAsync();
        //            return Content(jsondata, "application/json");
        //        }
        //        return Json(1, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult> GetClimate(string url )
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HttpResponseMessage response = await client.PostAsync("/climate");
                //if (response.IsSuccessStatusCode)
                //{
                //    string jsondata = await response.Content.ReadAsStringAsync();
                //    return Content(jsondata, "application/json");
                //}
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpGet]
        //public async Task<JsonResult> GetWindy(string urlBase, )
        //{
        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri(urlBase);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync("/climate");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsondata = await response.Content.ReadAsStringAsync();
        //            return Content(jsondata, "application/json");
        //        }
        //        return Json(1, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}