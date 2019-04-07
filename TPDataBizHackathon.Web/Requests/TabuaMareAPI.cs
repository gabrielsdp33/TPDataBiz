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
    public class TabuaMareAPI : RequestAPI
    {
        public TabuaMareAPI() : base("http://servicos.cptec.inpe.br/")
        {
        }

        public override Task<string> sendGetRequisiton(string url = "XML/cidade/4748/todos/tempos/ondas.xml")
        {
            return base.sendGetRequisiton(url);
        }

        public List<TabuaMare> getTabuaMare()
        {
            List<TabuaMare> listTabuaMare = new List<TabuaMare>();

            try
            {
                string response = sendGetRequisiton().Result;
                listTabuaMare = TabuaMareXMLReader.XmlToListTabuaMare(response);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return listTabuaMare;
        }
    }
}