using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace WeatherBot
{
    internal class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();

        private DiscordSocketClient _client;
        private WeatherChecker weatherChecker;

        /**
         * <summary>
         * Entry point of the program.
         * </summary>
         */
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            
            string token = File.ReadAllText("../../token.txt");
            await Log(new LogMessage(LogSeverity.Debug, "Main", "Token read successfully"));

            weatherChecker = new WeatherChecker();

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            
            

            // Block this task until the program is closed.
            await Task.Delay(-1);
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