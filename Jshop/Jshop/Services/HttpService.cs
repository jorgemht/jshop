namespace Jshop.Services
{
    using Jshop.Common;
    using Jshop.Helpers;
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
        private readonly string UrlApi = "YOUR_API";
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

                var list = JsonConvert.DeserializeObject<List<T>>(result);

                //  var list = JsonConvert.DeserializeObject<T>(result);

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

        public async Task<Response> GetTokenUser(string path, UserApp model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(UrlApi)
                };

                var url = $"{_servicePrefix}{path}";
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.Version.ToString()
                    };
                }

                var result = await response.Content.ReadAsStringAsync();

                var newRecord = JsonConvert.DeserializeObject<TokenResponse>(result);

                if(newRecord != null)
                {
                    Settings.AccessToken = newRecord.token;
                }

                return new Response
                {
                    IsSuccess = true,
                    Message = "Record added OK",
                    Result = newRecord,
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

        /*
        public async Task<Response> GetTokenUser<T>(string path, T model)
        {
            try
            {
                var client = new HttpClient();
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
        */
        public async Task<TokenResponse> GetToken()
        {
            const string userToken = "jorge@store.com";
            const string userPass = "123321";

            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(UrlApi)
                };
                var response = await client.PostAsync("Token",
                    new StringContent($"grant_type=password&username={userToken}&password={userPass}",
                        Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(resultJson);
                return result;
            }
            catch
            {
                return null;
            }
        }

    }
}
