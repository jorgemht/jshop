namespace Jshop.Services
{
    using Common;
    using Helpers;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpService
    {
        private readonly string _servicePrefix = "/api/";
        private readonly string UrlApi = "#";
        private string tokenType = "bearer";

        public async Task<Response> Get<T>(string path)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, Settings.AccessToken);
                client.BaseAddress = new Uri(UrlApi);

                var url = $"{_servicePrefix}{path}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetList<T>(string path, string parameters = null)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, Settings.AccessToken);
                client.BaseAddress = new Uri(UrlApi);

                var url = $"{_servicePrefix}{path}";

                if (false == string.IsNullOrEmpty(parameters))
                {
                    url += parameters;
                }

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<IEnumerable<T>>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    
        public async Task<TokenResponse> GetToken()
        {
            var user = new UserApp
            {
                Email = "jorge@store.com",
                Password = "123321"
            };

            try
            {
                var request = JsonConvert.SerializeObject(user);
                var content = new StringContent(
                    request, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(UrlApi)
                };

                var url = $"{_servicePrefix}{"account/login"}";
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();

                var newRecord = JsonConvert.DeserializeObject<TokenResponse>(result);

                return new TokenResponse
                {
                    expiration = newRecord.expiration,
                    token = newRecord.token
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
