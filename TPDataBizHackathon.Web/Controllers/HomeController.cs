using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPDataBizHackathon.Application.IAppServices;
using TPDataBizHackathon.Infra.IoC;

namespace TPDataBizHackathon.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAppServiceBase _appServiceBase;

        public HomeController()
        {
            BootStrapper.Start();
            _appServiceBase = BootStrapper.container.GetInstance<IAppServiceBase>();
        }

        public ActionResult Index()
        {
            List<string> model = _appServiceBase.getNavio().ToList<string>();

            return View(model);
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