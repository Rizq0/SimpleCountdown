using ArcRaidersCountdown.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
class Program
{     static async Task Main(string[] args)
    {

        var config = new ConfigurationBuilder()
           .AddUserSecrets<Program>()
           .AddEnvironmentVariables()    
           .Build();
        var webhookUrl = config["DISCORD_WEBHOOK"];

        DateTime releaseDate = new DateTime(2025, 10, 30);
        DateTime today = DateTime.Today;
        string countdownMessage = CountdownService.GetCountdownMessage(today, releaseDate);
        Console.WriteLine("Webhook loaded? " + (webhookUrl != null));
        int daysUntilRelease = (releaseDate - today).Days;
        if (daysUntilRelease < 0)
        {
            Console.WriteLine("Arc Raiders has already been released.");
            return;
        }

        if (webhookUrl == null)
        {
            Console.WriteLine("DISCORD_WEBHOOK environment variable is not set.");
            return;
        }

        var service = new WebService(new HttpClient());
        string postToDiscord = await service.SendDiscordMessage(webhookUrl, countdownMessage);

        Console.WriteLine(countdownMessage);
        Console.WriteLine(postToDiscord);
    }
}


