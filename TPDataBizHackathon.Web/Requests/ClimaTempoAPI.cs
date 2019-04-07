using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TPDataBizHackathon.Web.Models;
using TPDataBizHackathon.Web.Utils;

namespace TPDataBizHackathon.Web.Requests
{
    public class ClimaTempoAPI : RequestAPI
    {
        private string token;
        private string id_city;
        private string _url;

        public ClimaTempoAPI() : base("http://apiadvisor.climatempo.com.br/")
        {

            this.id_city = "3675";
            this.token = "2956f42968267cde606cbda8d6cf9fc1";
            this._url = string.Format("api/v1/forecast/locale/{0}/days/15?token={1}", this.id_city, this.token);
        }

        public override Task<string> sendGetRequisiton(string url = null)
        {
            if (string.IsNullOrEmpty(url))
                url = this._url;

            return base.sendGetRequisiton(url);
        }

        public ClimaTempo getToday()
        {
            ClimaTempo climaTempo = null;

            try
            {
                climaTempo = getWeek().Where(x => x.data.Date == DateTime.Now.Date).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return climaTempo;
        }

        public List<ClimaTempo> getWeek()
        {
            List<ClimaTempo> list = new List<ClimaTempo>();

            try
            {
                string response = sendGetRequisiton().Result;
                list = ClimaTempoUtils.JsonConverter(response);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return list;
        }
    }
}