using System;
using ArcRaidersCountdown.Services;
class Program
{     static void Main(string[] args)
    {
        DateTime releaseDate = new DateTime(2025, 10, 30);
        DateTime today = DateTime.Today;
        string countdownMessage = CountdownService.GetCountdownMessage(today, releaseDate);
        Console.WriteLine(countdownMessage);
    }
}