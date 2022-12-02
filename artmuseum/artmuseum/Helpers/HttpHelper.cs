using artmuseum.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace artmuseum.Helpers
{
    public class HttpHelper
    {

        public async Task<APIResponse> callAPI(string url,string json)
        {
            APIResponse res = new APIResponse();
            try
            {
                string content = string.Empty;
                var httpClient = new HttpClient();
                HttpResponseMessage httpResponse = null;
                if (String.IsNullOrWhiteSpace(json))
                {
                    httpResponse = await httpClient.GetAsync(url);
                }
                else
                {
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    httpResponse = await httpClient.PostAsync(url, httpContent);

                }

                if (httpResponse.IsSuccessStatusCode)
                {
                    content = await httpResponse.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<APIResponse>(content);
                }
                else
                {
                    res.response = null;
                    res.message = "Invalid Response";
                    res.result = false;
                }

                return res;
            }
            catch (Exception ex)
            {
                res.response = ex.Message.ToString();
                res.message = "Invalid Response";
                res.result = false;

                return res;
            }
        }

    }
}
