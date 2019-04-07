using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TPDataBizHackathon.Web.Requests
{
    public class RequestAPI
    {
        private HttpClient httpClient;

        public RequestAPI(string urlBase)
        {
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient.BaseAddress = new Uri(urlBase);
        }

        public virtual async Task<string> sendGetRequisiton(string url)
        {
            string response = null;

            try
            {
                HttpResponseMessage httpResponseMessage = (HttpResponseMessage)await this.httpClient.GetAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode)
                    response = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return response;
        }
    }
}