using RainbowSix.WebClient.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace RainbowSix.WebClient
{
    public class HttpConnection : IDisposable
    {
        protected readonly IHttpConnectionLogger _logger;
        protected readonly HttpClient _httpClient;
        protected readonly HttpClientHandler _httpClientHandler;
        protected readonly CookieContainer _cookieContainer;

        public HttpConnection(IHttpConnectionLogger logger, Uri baseUrl, bool ignoreSSLCertErrors = false)
            :this(logger, ignoreSSLCertErrors)
        {
            _httpClient.BaseAddress = baseUrl;
        }
        public HttpConnection(IHttpConnectionLogger logger, bool ignoreSSLCertErrors = false)
        {
            _logger = logger;
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler()
            {
                CookieContainer = _cookieContainer,
                AllowAutoRedirect = true
            };
            if (ignoreSSLCertErrors)
            {
                _httpClientHandler.ServerCertificateCustomValidationCallback
                    = (httpRequestMessage, cert, cetChain, policyErrors) => true;
            }
            _httpClient = new HttpClient(_httpClientHandler, false);
        }

        public void ClearRequestHeaders() => _httpClient.DefaultRequestHeaders.Clear();

        public void SetRequestHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        public void SetDefaultRequestHeaders()
        {
            SetRequestHeaders(new Dictionary<string, string>
            {
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                                "AppleWebKit/537.36 (KHTML, like Gecko) " +
                                "Chrome/92.0.4515.159 Safari/537.36" },
                { "Cache-Control", "no-cache" },
                { "accept-language", "en-US,en;q=0.9" }
            });
        }

        public Dictionary<string, string> Cookies
        {
            get => GetCookies();
            set => SetCookies(value);
        }

        private Dictionary<string, string> GetCookies()
        {
            var cookieCollection = _cookieContainer.GetCookies(_httpClient.BaseAddress);
            var cookieDictionary = new Dictionary<string, string>();
            foreach (Cookie cookie in cookieCollection)
            {
                cookieDictionary[cookie.Name] = cookie.Value;
            }
            return cookieDictionary;
        }

        private void SetCookies(Dictionary<string, string> cookiesDictionary)
        {
            var cookies = new List<string>();
            foreach (var cookie in cookiesDictionary)
            {
                cookies.Add($"{cookie.Key}={cookie.Value}");
            }
            _cookieContainer.SetCookies(_httpClient.BaseAddress, string.Join("; ", cookies));
        }

        public async Task<Stream> GetStreamAsync(string requestUri) => await _httpClient.GetStreamAsync(requestUri);

        private async Task LogRequestAndResponseAsync(HttpRequestMessage request, HttpResponseMessage response)
        {
            var sb = new StringBuilder();
            sb.AppendLine("===== HTTP REQUEST =====");
            sb.AppendLine($"{request.Method} {request.RequestUri}");
            sb.AppendLine("Headers:");
            foreach (var header in request.Headers)
                sb.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");

            if (request.Content != null)
            {
                foreach (var header in request.Content.Headers)
                    sb.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");

                var requestBody = await request.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(requestBody))
                {
                    sb.AppendLine("Body:");
                    try
                    {
                        var parsedJson = JsonSerializer.Deserialize<object>(requestBody);
                        sb.AppendLine(JsonSerializer.Serialize(parsedJson));
                    }
                    catch
                    {
                        sb.AppendLine(requestBody);
                    }
                }
            }

            sb.AppendLine("\n===== HTTP RESPONSE =====");
            sb.AppendLine($"Status Code: {response.StatusCode}");
            sb.AppendLine("Headers:");
            foreach (var header in response.Headers)
                sb.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");
            if (response.Content != null)
            {
                foreach (var header in response.Content.Headers)
                    sb.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");

                if (response.Content.Headers.ContentLength > 10240) // 10 KB limit
                {
                    sb.AppendLine("Body: [Content too large to log]");
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(responseBody))
                    {
                        sb.AppendLine("Body:");
                        try
                        {
                            var parsedJson = JsonSerializer.Deserialize<object>(responseBody);
                            sb.AppendLine(JsonSerializer.Serialize(parsedJson));
                        }
                        catch
                        {
                            sb.AppendLine(responseBody);
                        }
                    }
                }
            }

            sb.AppendLine("=========================\n");
            _logger.WriteLine(sb.ToString());
        }

        public async Task<string> GetAsync(string requestUri, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            using var response = await _httpClient.SendAsync(request, cancellationToken);
            await LogRequestAndResponseAsync(request, response);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<TReceive> GetAsJsonAsync<TReceive>(string requestUri)
        {
            var responseString = await GetAsync(requestUri);
            return JsonSerializer.Deserialize<TReceive>(responseString)!;
        }

        public async Task<string> PostAsync(string requestUri, FormUrlEncodedContent formUrlEncodedContent)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = formUrlEncodedContent };
            var response = await _httpClient.SendAsync(request);
            await LogRequestAndResponseAsync(request, response);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<TReceive> PostAsync<TReceive>(string requestUri, FormUrlEncodedContent formUrlEncodedContent)
        {
            var responseString = await PostAsync(requestUri, formUrlEncodedContent);
            return JsonSerializer.Deserialize<TReceive>(responseString)!;
        }

        public async Task<string> PostAsJsonAsync<TSend>(string requestUri, TSend model)
        {
            var json = JsonSerializer.Serialize(model);
            using var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            var response = await _httpClient.SendAsync(request);
            await LogRequestAndResponseAsync(request, response);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<TReceive> PostAsJsonAsync<TSend, TReceive>(string requestUri, TSend model)
        {
            var responseString = await PostAsJsonAsync(requestUri, model);
            return JsonSerializer.Deserialize<TReceive>(responseString)!;
        }

        public void Dispose()
        {
            _httpClientHandler.Dispose();
            _httpClient.Dispose();
        }
    }
}
