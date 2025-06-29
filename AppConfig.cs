
using Microsoft.Extensions.Configuration;
namespace SimpleCountdown;

public class AppConfig
{
    public string WebhookUrl { get; }
    public string RequiredService { get; }
    public DateTime TargetDate { get; }

    public AppConfig()
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()    
            .Build();
        
        WebhookUrl = config["DISCORD_WEBHOOK"] ?? throw new Exception("DISCORD_WEBHOOK environment variable is not set.");
        RequiredService = config["SERVICE"] ?? throw new Exception("SERVICE environment variable is not set.");
        var targetDateString = config["TARGET"] ?? throw new Exception("TARGET environment variable is not set.");

        if (!DateTime.TryParse(targetDateString, out var targetDate))
            throw new Exception("Invalid TARGET date format. Use yyyy-MM-dd.");
        TargetDate = targetDate;
    }
}   