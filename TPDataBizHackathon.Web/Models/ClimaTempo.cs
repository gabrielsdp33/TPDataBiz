using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDataBizHackathon.Web.Models
{
    public class ClimaTempo
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public DateTime data_requisicao { get; set; }

        public DateTime data { get; set; }

        public double humidityMin { get; set; }
        public double humidityMax { get; set; }

        public double rainProbability { get; set; }
        public double rainPrecipitation { get; set; }

        public double windVelocityMin { get; set; }
        public double windVelocityMax { get; set; }

        public double uvMax { get; set; }

        public double thermalSensationMin { get; set; }
        public double thermalSensationMax { get; set; }

        public string text { get; set; }
        public string description { get; set; }

        public double temperatureMaxNow { get; set; }
        public double temperatureMinNow { get; set; }

        public double temperatureMorningMin { get; set; }
        public double temperatureMorningMax { get; set; }

        public double temperatureAfternoonMin { get; set; }
        public double temperatureAfternoonMax { get; set; }

        public double temperatureNightMin { get; set; }
        public double temperatureNightMax { get; set; }

        public string imgSrc { get; set; }
        public string diaSemana { get; set; }
    }
}