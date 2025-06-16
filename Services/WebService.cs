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
                var payload = new { content = message };
                var json = System.Text.Json.JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response from Discord: {responseBody}");
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