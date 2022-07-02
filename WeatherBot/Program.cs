using System;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using WeatherBot.Models;

namespace WeatherBot
{
    internal class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();

        private static DiscordSocketClient _client = new DiscordSocketClient();
        private static Timer _timer;
        private WeatherChecker _weatherChecker;
        private WeatherReport _report;

        /**
         * <summary>
         * Entry point of the program.
         * </summary>
         */
        public async Task MainAsync()
        {
            _client.Log += Log;
            
            var token = File.ReadAllText(@"../../token.txt");
            await Log(new LogMessage(LogSeverity.Debug, "Main", "Token read successfully"));

            _weatherChecker = new WeatherChecker("Omaha, Nebraska");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            
            SetTimer();
            

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        
        private void SetTimer()
        {
            // timer = new Timer(1000*60*60*12); //12 hours in ms
            _timer = new Timer(10000);
            
            _timer.Elapsed += async ( sender, e ) => await AnnounceWeather();
            _timer.AutoReset = true;
            _timer.Enabled = true;
            
            _timer.Start();
        }

        private Task AnnounceWeather()
        {
            var raw = _weatherChecker.GetWeather().Result;
            Console.WriteLine(raw);
            _report = JsonConvert.DeserializeObject<WeatherReport>(raw);
     
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