using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using TPDataBizHackathon.Web.Models;
using TPDataBizHackathon.Web.Utils;

namespace TPDataBizHackathon.Web.Requests
{
    public class TabuaMareAPI : RequestAPI
    {
        private HttpClient _client;

        public TabuaMareAPI() : base("http://servicos.cptec.inpe.br/")
        {
            _client = new HttpClient();

        }

        public override Task<string> sendGetRequisiton(string url = "http://servicos.cptec.inpe.br/XML/cidade/7dias/4748/previsao.xml")
        {
            return base.sendGetRequisiton(url);
        }

        //public Task<string> getTabuaMare(string url = "http://servicos.cptec.inpe.br/XML/cidade/7dias/4748/previsao.xml")
        //{

        //    XmlDocument doc = (XmlDocument)_client.GetAsync(url);
        //    doc.Load(doc)
        //    return base.sendGetRequisiton(url);
        //}

        //public async Task<List<TabuaMare>> getTabuaMare()
        //{
        //    //List<TabuaMare> listTabuaMare = new List<TabuaMare>();

            
        //    try
        //    {
        //        string url = "http://servicos.cptec.inpe.br/XML/cidade/7dias/4748/previsao.xml";

        //        HttpResponseMessage response = await _client.GetAsync(url);
        //        List<TabuaMare> listTabuaMare = TabuaMareXMLReader.XmlToListTabuaMare(response.Content.ToString());

        //        return listTabuaMare;
        //    }

        //    catch (Exception e)
        //    {
        //        Debug.Write(e.Message);
        //    }
            

        //    //return listTabuaMare;
        //}

        
    }
}