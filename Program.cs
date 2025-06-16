using System;
using ArcRaidersCountdown.Services;
using System.Net.Http;
class Program
{     static async Task Main(string[] args)
    {
        DateTime releaseDate = new DateTime(2025, 10, 30);
        DateTime today = DateTime.Today;
        string countdownMessage = CountdownService.GetCountdownMessage(today, releaseDate);
        var service = new WebService(new HttpClient());
        string testPing = await service.SendDiscordMessage("https://jsonplaceholder.typicode.com/posts/1", countdownMessage);
        Console.WriteLine(countdownMessage);
        Console.WriteLine(testPing);
    }
}


