using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ArcRaidersCountdown.Services
{
    internal class WebService
    {
        private readonly HttpClient _httpClient;

        public WebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendDiscordMessage(string webhookUrl, string message)
        {
            try
            {
                var response = await _httpClient.GetAsync(webhookUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                string errorMessage = $"Request error: {e.Message}";
                Console.WriteLine(errorMessage);
                return errorMessage;
            }

        }
    }
}