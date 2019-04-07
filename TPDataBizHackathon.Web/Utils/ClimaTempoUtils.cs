using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using TPDataBizHackathon.Web.Models;

namespace TPDataBizHackathon.Web.Utils
{
    public class ClimaTempoUtils
    {
        public static List<ClimaTempo> JsonConverter(string json)
        {
            List<ClimaTempo> result = new List<ClimaTempo>();
            CultureInfo provider = new CultureInfo("pt-BR");

            try
            {
                JObject jObj = JObject.Parse(json);

                foreach (JProperty jObjProperties in jObj.Properties())
                {
                    if (jObjProperties.Name != null && jObjProperties.Name.Contains("error"))
                    {
                        throw new Exception("Error calling API");
                    }
                }

                string id = jObj["id"].ToString();
                string cidade = jObj["name"].ToString();
                string state = jObj["state"].ToString();
                string country = jObj["country"].ToString();

                JArray data = JArray.Parse(jObj["data"].ToString());

                foreach (JObject item in data.Children<JObject>())
                {
                    JObject humidity = JObject.Parse(item["humidity"].ToString());
                    JObject rain = JObject.Parse(item["rain"].ToString());
                    JObject wind = JObject.Parse(item["wind"].ToString());
                    JObject uv = JObject.Parse(item["uv"].ToString());
                    JObject thermalSensation = JObject.Parse(item["thermal_sensation"].ToString());

                    JObject textIcon = JObject.Parse(item["text_icon"].ToString());
                    JObject icon = JObject.Parse(textIcon["icon"].ToString());
                    JObject text = JObject.Parse(textIcon["text"].ToString());
                    JObject phrase = JObject.Parse(text["phrase"].ToString());

                    JObject temperature = JObject.Parse(item["temperature"].ToString());
                    JObject morning = JObject.Parse(temperature["morning"].ToString());
                    JObject afternoon = JObject.Parse(temperature["afternoon"].ToString());
                    JObject night = JObject.Parse(temperature["night"].ToString());

                    int hourNow = (int)DateTime.Now.Hour;
                    string nameIcon = string.Empty;

                    if (hourNow >= 6 && hourNow <= 12)
                    {
                        //manha
                        nameIcon = (string)icon["morning"];
                    }
                    else if (hourNow >= 13 && hourNow <= 18)
                    {
                        //tarde
                        nameIcon = (string)icon["afternoon"];
                    }
                    else
                    {
                        //noite - madruga
                        nameIcon = (string)icon["night"];
                    }

                    result.Add
                    (
                        new ClimaTempo
                        {
                            id = Guid.NewGuid(),
                            name = cidade,
                            state = state,
                            country = country,
                            data_requisicao = DateTime.Today,

                            data = DateTime.ParseExact((string)item["date_br"], "dd/MM/yyyy", provider),

                            humidityMax = (double)humidity["max"],
                            humidityMin = (double)humidity["min"],

                            rainProbability = (double)rain["probability"],
                            rainPrecipitation = (double)rain["precipitation"],

                            windVelocityMax = (double)wind["velocity_max"],
                            windVelocityMin = (double)wind["velocity_min"],

                            uvMax = (double)uv["max"],

                            thermalSensationMax = (double)thermalSensation["max"],
                            thermalSensationMin = (double)thermalSensation["min"],

                            text = (string)text["pt"],
                            description = (string)phrase["reduced"],

                            temperatureMaxNow = (double)temperature["max"],
                            temperatureMinNow = (double)temperature["min"],

                            temperatureMorningMax = (double)morning["max"],
                            temperatureMorningMin = (double)morning["min"],

                            temperatureAfternoonMax = (double)afternoon["max"],
                            temperatureAfternoonMin = (double)afternoon["min"],

                            temperatureNightMax = (double)night["max"],
                            temperatureNightMin = (double)night["min"],

                            imgSrc = nameIcon + ".png",
                            diaSemana = DateTime.ParseExact((string)item["date_br"], "dd/MM/yyyy", provider).ToString("dddd", new CultureInfo("pt-BR"))
                                .First()
                                .ToString()
                                .ToUpper() +
                                DateTime.ParseExact((string)item["date_br"], "dd/MM/yyyy", provider).ToString("dddd", new CultureInfo("pt-BR"))
                                .Substring(1)
                        }
                    );
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return result;
        }
    }
}