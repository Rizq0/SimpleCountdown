
# Simple Countdown

A simple C# console app that sends a countdown message to a Discord webhook for a service release. Currently supports Arc Raiders, but services can be added as needed.

## Configuration

Set the following environment variables:

- `DISCORD_WEBHOOK`: Your Discord webhook URL
- `SERVICE`: The service name (e.g., `Arc Raiders`)
- `TARGET`: Target release date in `yyyy-MM-dd` format (e.g., `2025-10-30`)

## Usage

1. Build the project.
2. Set the environment variables.
3. Run the app.

The app will send a countdown message to your Discord channel.
