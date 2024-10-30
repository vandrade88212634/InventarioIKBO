namespace Common.Utils.RestServices
{
    using Common.Utils.Dto;
    using Common.Utils.Excepcions;
    using Common.Utils.RestServices.Interface;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Security;
    using System.Text;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class RestService : IRestService
    {
        // Post
        public async Task<T> PostRestServiceAsync<T>(string url, string controller,
           string method, object parameters, IDictionary<string, string> headers)
        {
            var baseUrl = string.Format("{0}/{1}/{2}", url, controller, method);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                HttpContent jsonObject = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(baseUrl, jsonObject);

                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        var data = await res.Content.ReadAsStringAsync();
                        var objResponse = JsonConvert.DeserializeObject<ResponseModelDto<object>>(data);

                        throw new BusinessException(objResponse.Messages);
                    }
                }

                throw new ArgumentException(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));
            }
        }

        public async Task<T> PostRestServiceStringParametersAsync<T>(string url, string controller, string method, IDictionary<string, string> parameters, IDictionary<string, string> headers)
        {
            var urlBase = string.Format("{0}/{1}/{2}", url, controller, method);

            if (parameters.Count > 0)
                urlBase = urlBase + "?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value).ToArray());

            using (HttpClient clientHttp = new HttpClient())
            {
                clientHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var itemHeader in headers)
                    {
                        clientHttp.DefaultRequestHeaders.Add(itemHeader.Key, itemHeader.Value);
                    }
                }

                HttpContent jsonContent = new StringContent(string.Empty);
                HttpResponseMessage resultResonse = await clientHttp.PostAsync(urlBase, jsonContent);
                if (resultResonse.IsSuccessStatusCode)
                {
                    var data = await resultResonse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    if (resultResonse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        var dataString = await resultResonse.Content.ReadAsStringAsync();
                        var jsonResponse = JsonConvert.DeserializeObject<ResponseModelDto<object>>(dataString);

                        throw new BusinessException(jsonResponse.Messages);
                    }
                }

                throw new ArgumentException(string.Format("{0},{1},{2},{3}", url, resultResonse.StatusCode, resultResonse.Content, urlBase));
            }
        }

        // Get
        public async Task<T> GetRestServiceAsync<T>(string url, string controller, string method,
            IDictionary<string, string> parameters, IDictionary<string, string> headers)
        {
            this.ValidationParameterApi(parameters);

            string baseUrlRest = string.Format("{0}/{1}/{2}", url, controller, method);

            if (parameters.Count > 0)
                baseUrlRest = baseUrlRest + "?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value).ToArray());

            using (HttpClient clientResquet = new HttpClient())
            {
                clientResquet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        clientResquet.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage httpResponse = await clientResquet.GetAsync(baseUrlRest);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var dataResult = await httpResponse.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(dataResult);
                }
                else
                {
                    if (httpResponse.StatusCode.Equals(StatusCodes.Status400BadRequest))
                    {
                        var dataRead = await httpResponse.Content.ReadAsStringAsync();
                        var responseConvert = JsonConvert.DeserializeObject<ResponseModelDto<object>>(dataRead);

                        throw new BusinessException(responseConvert.Messages);
                    }
                }

                throw new ArgumentException(string.Format("{0},{1},{2},{3}", url, httpResponse.StatusCode, httpResponse.Content, baseUrlRest));
            }
        }

        private void ValidationParameterApi(IDictionary<string, string> parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
        }

        public async Task<T> GetRestServiceAsyncList<T>(string url, string controller, string method,
          IDictionary<string, string[]> parameters, IDictionary<string, string> headers)
        {
            string endPointUrl = string.Format("{0}/{1}/{2}", url, controller, method);

            if (parameters.Count > 0)
                endPointUrl = endPointUrl + "?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value).ToArray());

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage responseResultMesagge = await httpClient.GetAsync(endPointUrl);

                if (responseResultMesagge.IsSuccessStatusCode)
                {
                    var data = await responseResultMesagge.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    if (responseResultMesagge.StatusCode.Equals(StatusCodes.Status400BadRequest))
                    {
                        var stringData = await responseResultMesagge.Content.ReadAsStringAsync();
                        var resonposeJson = JsonConvert.DeserializeObject<ResponseModelDto<object>>(stringData);

                        throw new BusinessException(resonposeJson.Messages);
                    }
                }

                throw new ArgumentException(string.Format("{0},{1},{2},{3}", url, responseResultMesagge.StatusCode, responseResultMesagge.Content, endPointUrl));
            }
        }

        public bool PostRestServicePortalAsync(byte[] fileByte, string url, string fileName, string token)
        {
            var _httpClient = new HttpClient();

            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new ByteArrayContent(fileByte, 0, fileByte.Length), "archivo", fileName);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = multiPartStream;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                request.Headers.Add("Authorization", token);

                HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) =>
                {
                    return sslPolicyErrors == SslPolicyErrors.None;
                });

                using (HttpResponseMessage response = _httpClient.SendAsync(request, option).Result)
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }
    }
}