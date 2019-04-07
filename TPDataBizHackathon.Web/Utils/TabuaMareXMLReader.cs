using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;
using TPDataBizHackathon.Web.Models;

namespace TPDataBizHackathon.Web.Utils
{
    public class TabuaMareXMLReader
    {
        public static List<TabuaMare> XmlToListTabuaMare(string xml)
        {

            List<TabuaMare> listTabuaMare = new List<TabuaMare>();

            try
            {
                CultureInfo provider = new CultureInfo("pt-BR");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
                XmlNodeList previsao = xmlDocument.GetElementsByTagName("previsao");

                string uf = xmlDocument.GetElementsByTagName("uf").Item(0).InnerText;
                string cidade = xmlDocument.GetElementsByTagName("nome").Item(0).InnerText;
                DateTime atualizacao = DateTime.Parse(xmlDocument.GetElementsByTagName("atualizacao").Item(0).InnerText);

                TabuaMare tabuaMare = null;
                for (int i = 0; i < previsao.Count; i++)
                {
                    string hora = previsao[i].ChildNodes.Item(0).InnerText.Substring(11, 3);

                    if (tabuaMare == null)
                    {
                        tabuaMare = new TabuaMare();
                        tabuaMare.id = Guid.NewGuid();
                    }

                    DateTime _dia = Utils.strToDateTime("dd-MM-yyyy", previsao[i].ChildNodes.Item(0).InnerText.Substring(0, 10)); //DateTime.Parse(previsao[i].ChildNodes.Item(0).InnerText.Substring(0,10));
                    if (tabuaMare.dia != null && tabuaMare.dia != _dia)
                    {
                        tabuaMare = new TabuaMare();
                        tabuaMare.id = Guid.NewGuid();
                    }

                    tabuaMare.atualizacao = atualizacao;
                    tabuaMare.cidade = cidade;
                    tabuaMare.uf = uf;
                    tabuaMare.hora.Add(hora);

                    tabuaMare.dia = _dia;
                    tabuaMare.agitacao[hora] = previsao[i].ChildNodes.Item(1).InnerText;
                    tabuaMare.altura[hora] = double.Parse(previsao[i].ChildNodes.Item(2).InnerText);
                    tabuaMare.direcao[hora] = previsao[i].ChildNodes.Item(3).InnerText;
                    tabuaMare.vento[hora] = double.Parse(previsao[i].ChildNodes.Item(4).InnerText);
                    tabuaMare.vento_dir[hora] = previsao[i].ChildNodes.Item(5).InnerText;

                    listTabuaMare.Remove(listTabuaMare.Where(x => x.id == tabuaMare.id).FirstOrDefault());
                    listTabuaMare.Add(tabuaMare);
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            return listTabuaMare;

        }
    }
}