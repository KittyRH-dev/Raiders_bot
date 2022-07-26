using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Raiders_Jester
{
    class Program
    {
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandHandler;
            client.Log += Log;

            YamlSerialization.Config_Yaml();

            await client.LoginAsync(TokenType.Bot, YamlSerialization.token);
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task<Task> CommandHandler(SocketMessage message)
        {
            string command = "";
            int lengthOfCommand = -1;

            if (!message.Content.StartsWith("!"))
                return Task.CompletedTask;

            if (message.Author.IsBot)
                return Task.CompletedTask;

            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            while(true)
            {
                Serverstatus.Serverping_DCSServer();
                Task.Delay(TimeSpan.FromMinutes(5));

                
            }

            if (command.Equals("server"))
            {
                Serverstatus.Serverping_DCSServer();

                message.Channel.SendMessageAsync(message.Author.Mention + " Pinging Server... " + "\n" + Serverstatus.Serverping_DCSServer);
            }

            return Task.CompletedTask;
        }


    }
}
