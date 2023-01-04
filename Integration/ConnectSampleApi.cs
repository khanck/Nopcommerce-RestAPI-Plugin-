using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.ConnectApi.Models;
using ILogger = Nop.Services.Logging.ILogger;

namespace Nop.Plugin.Misc.ConnectApi.Integration
{
    internal class ConnectSampleApi
    {
        private static ConnectApiSettings _connectApiSettings;
        private readonly ILogger _logger;
        private static int _reqTimeout = 30;

        public ConnectSampleApi(ConnectApiSettings connectApiSettings, ILogger logger)
        {
            _connectApiSettings = connectApiSettings;
            _logger = logger;
        }
        public List<ApiResultItemModel> GetAllEmployees()
        {
            List<ApiResultItemModel> result = new List<ApiResultItemModel>();

            Task.Run(async () =>
            {
                try
                {
                    string uri = String.Format(_connectApiSettings.ConnectApiUrl + "{0}", "v1/employees");

                    HttpClient client = GetHttpClient();                   
                 

                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            result = JsonConvert.DeserializeObject<List<ApiResultItemModel>>(await response.Content.ReadAsStringAsync());
                        }
                        else
                        {
                            await _logger.ErrorAsync(response.StatusCode.ToString(), new Exception(await response.Content.ReadAsStringAsync()));

                        }
                    }

                }
                catch (Exception ex)
                {
                    await _logger.ErrorAsync(ex.Message, ex);
                }

            }).Wait();
            return result;

        }

        public List<ApiResultItemModel> CreateEmployee(ApiResultItemModel employee)
        {
            List<ApiResultItemModel> result = new List<ApiResultItemModel>();

            Task.Run(async () =>
            {
                try
                {
                    string uri = String.Format(_connectApiSettings.ConnectApiUrl + "{0}", "v1/create");

                    HttpClient client = GetHttpClient();

                    string inputJson = JsonConvert.SerializeObject(employee);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await client.PostAsync(uri, inputContent))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            result = JsonConvert.DeserializeObject<List<ApiResultItemModel>>(await response.Content.ReadAsStringAsync());
                        }
                        else
                        {
                            await _logger.ErrorAsync(response.StatusCode.ToString(), new Exception(await response.Content.ReadAsStringAsync()));

                        }
                    }

                }
                catch (Exception ex)
                {
                    await _logger.ErrorAsync(ex.Message, ex);
                }

            }).Wait();
            return result;

        }

        // adding basic Authentication if needed for some apis 
        public AuthenticationHeaderValue GetAuthenticationHeader()
        {
            var user = Encoding.ASCII.GetBytes(_connectApiSettings.ConnectApiUser + ":" + _connectApiSettings.ConnectApiPass);
            return new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(user));
        }
        public HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = GetAuthenticationHeader();
            client.Timeout = TimeSpan.FromSeconds(_reqTimeout);
            return client;

        }

    }
}

