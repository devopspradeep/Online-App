using Newtonsoft.Json;
using OnlineApp.Web.UI.IServices;
using OnlineApp.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Web.UI.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }

        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory;
            this.responseModel = new ResponseDto();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("ProductAPI");
                client.DefaultRequestHeaders.Clear();
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept","application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,"application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch(apiRequest.ApiType)
                {
                    
                    case StaticConfiguration.ApiType.POST:
                                                        message.Method = HttpMethod.Post;
                                                        break;
                    case StaticConfiguration.ApiType.DELETE:
                                                        message.Method = HttpMethod.Delete;
                                                        break;
                    case StaticConfiguration.ApiType.PUT:
                                                        message.Method = HttpMethod.Put;
                                                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string>
                    {
                        Convert.ToString(ex.Message)
                    }
                    , IsSuccess = false
                };
                 var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;

            }
        }
    }
}
