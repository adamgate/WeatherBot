using System;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using Discord;
using Discord.WebSocket;

namespace WeatherBot.Models
{
    internal class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();

        private DiscordSocketClient _client;
        private WeatherChecker weatherChecker;
        private static Timer timer;

        /**
         * <summary>
         * Entry point of the program.
         * </summary>
         */
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            
            var token = File.ReadAllText("../../token.txt");
            await Log(new LogMessage(LogSeverity.Debug, "Main", "Token read successfully"));

            weatherChecker = new WeatherChecker("Omaha, Nebraska");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            
            SetTimer();
            

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        
        private void SetTimer()
        {
            // timer = new Timer(1000*60*60*12); //12 hours in ms
            timer = new Timer(10000);
            
            timer.Elapsed += async ( sender, e ) => await AnnounceWeather();
            timer.AutoReset = true;
            timer.Enabled = true;
            
            timer.Start();
        }

        private Task AnnounceWeather()
        {
            Console.WriteLine(weatherChecker.GetWeather());
            return Task.CompletedTask;
        }
        
        /**
         * <summary>
         * Logs a message to the console.
         * </summary>
         * <param name="msg">The message to be logged.</param>
         */
        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}