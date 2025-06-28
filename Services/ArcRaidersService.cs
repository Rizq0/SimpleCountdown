using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ArcRaidersCountdown.Services
{
    internal class ArcRaidersService
    {
        private readonly HttpClient _httpClient;

        public ArcRaidersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public static string GetCountdownMessage(DateTime today, DateTime releaseDate)
        {
            int daysUntilRelease = (releaseDate - today).Days;

            if (daysUntilRelease > 0)
            {
                return $"ARC Raiders releases in {daysUntilRelease} days!";
            }
            else if (daysUntilRelease == 0)
            {
                return "ARC Raiders releases today!";
            }
            else
            {
                return "ARC Raiders has already been released.";
            }
        } 

        public async Task SendDiscordMessage(string webhookUrl, string message)
        {
            try
            {
                var payload = new { content = message };
                var json = System.Text.Json.JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                string errorMessage = $"Request error: {e.Message}";
                Console.WriteLine(errorMessage);
            }

        }
    }
}