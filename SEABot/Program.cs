using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace SEABot
{
    class Program
    {
        private static DiscordSocketClient _client;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World! I'm SEABot!");
            _client = new DiscordSocketClient();


            string token = Environment.GetEnvironmentVariable("discordBotToken");
            Setup(token).GetAwaiter().GetResult();
        }

        private static async Task Setup(string token)
        {
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            _client.MessageReceived += processMessage;
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private static async Task processMessage(SocketMessage arg)
        {
            if(arg.Content == "$status")
            {
               var x  = await arg.Channel.SendMessageAsync("Reporting for duty from .NET Core!");
            }
        }
    }
}
