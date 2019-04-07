using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace TPDataBizHackathon.API.Controllers
{
    public class TesteController : Controller
    {

        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        //[Route("api/Teste")]
        // GET: Teste
        public JsonResult Teste()
        {
            //HttpClient httpClient = new HttpClient();

            //httpClient.BaseAddress = "https://www.windguru.cz/int/iapi.php?q=station_data_current&id_station=87&date_format=Y-m-d+H%3Ai%3As+T"


            return Json(new { id = 1, value = "new" });
        }

        public async Task<ActionResult> GetClimate()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://www.windguru.cz/int/iapi.php?q=station_data_current&id_station=87&date_format=Y-m-d+H%3Ai%3As+T");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = await response.Content.ReadAsStringAsync();
                    return Content(jsondata, "application/json");
                }
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}