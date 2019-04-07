using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TPDataBizHackathon.Web.Utils
{
    public class Utils
    {
        public static DateTime strToDateTime(string format, string value)
        {
            DateTime date = DateTime.MinValue;
            int dia = 0;
            int mes = 0;
            int ano = 0;

            try
            {
                switch (format)
                {
                    case "dd/MM/yyyy":
                        dia = int.Parse(value.Substring(0, 2));
                        mes = int.Parse(value.Substring(3, 2));
                        ano = int.Parse(value.Substring(6, 4));
                        break;

                    case "dd-MM-yyyy":
                        dia = int.Parse(value.Substring(0, 2));
                        mes = int.Parse(value.Substring(3, 2));
                        ano = int.Parse(value.Substring(6, 4));
                        break;

                    case "yyyy-MM-dd":
                        dia = int.Parse(value.Substring(0, 4));
                        mes = int.Parse(value.Substring(3, 2));
                        ano = int.Parse(value.Substring(6, 2));
                        break;
                }

                date = new DateTime(ano, mes, dia);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return date;

        }
    }
}