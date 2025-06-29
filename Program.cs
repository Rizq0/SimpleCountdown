using SimpleCountdown.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using SimpleCountdown;

class Program
{     static async Task Main(string[] args)
    {
        AppConfig config;
        try
        {
            config = new AppConfig();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Config Error: {ex}");
            return;
        }
        
        DateTime today = DateTime.Today;
        int daysUntilRelease = (config.TargetDate - today).Days;
        if (daysUntilRelease < 0)
        {
            Console.WriteLine($"{config.RequiredService} has already been released.");
            return;
        }
        
        using var httpClient = new HttpClient();
        switch (config.RequiredService)
        {
            case "Arc Raiders":
                Console.WriteLine($"Using {config.RequiredService} Service");
                string countdownMessage = ArcRaidersService.GetCountdownMessage(today, config.TargetDate);
                var service = new ArcRaidersService(httpClient);
                await service.SendDiscordMessage(config.WebhookUrl, countdownMessage);
                break;
            default:
                Console.WriteLine($"Service '{config.RequiredService}' is not recognized.");
                return;
        }
        
    }
}


