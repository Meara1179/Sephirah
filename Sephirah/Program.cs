using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System.Reflection;
using DSharpPlus.Interactivity.Extensions;
using System.Configuration;

namespace Sephirah
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            DiscordActivity activity = new DiscordActivity();
            activity.Name = "Extracting E.G.O";

            var discord = new DiscordClient(discordConfig);
            var commands = discord.UseCommandsNext(commandConfig);
            var slashCommands = discord.UseSlashCommands(new SlashCommandsConfiguration());


            commands.RegisterCommands(Assembly.GetExecutingAssembly());
            slashCommands.RegisterCommands(Assembly.GetExecutingAssembly());

            discord.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = DSharpPlus.Interactivity.Enums.PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30)
            });

            // Just why???
            Console.WriteLine("Reintializing System...");
            await Task.Delay(1000);
            Console.WriteLine("Synchronizing Memory Repository...");
            await Task.Delay(1000);
            Console.WriteLine("Running Sephirot Protocol...");
            await Task.Delay(1000);
            Console.WriteLine("Beginning TT2 Acceleration...");
            await Task.Delay(1000);
            Console.WriteLine("Weakening Qliphoth Deterrence...");
            await Task.Delay(1000);
            Console.WriteLine("Resuming Energy Extraction and Refinement...");
            await Task.Delay(1000);
            Console.WriteLine("Checking TT2 Reconstruction...");
            await Task.Delay(1000);
            Console.WriteLine("Sephirot Reconstruction Complete...");
            await Task.Delay(1000);
            

            // Handles establishing a Async connection to the database.
            var database = new SqlCommands();
            bool databaseConnectionStatus = await database.PingDatabase();

            if (databaseConnectionStatus == true)   
            {
                Console.WriteLine("The Memories of all the Sephirot have been Synchronized.");
            }
            else
            {
                Console.WriteLine("Connection with database has failed.");
            }

            // Establishes a connection with Discord's servers.
            await discord.ConnectAsync(activity);
            await Task.Delay(-1);
        } 

        static DiscordConfiguration discordConfig = new DiscordConfiguration()
        {
            Token = GetBotToken(),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Information,
            LogTimestampFormat = "MMM dd yyyy - hh:mm:ss tt"
        };

        static CommandsNextConfiguration commandConfig = new CommandsNextConfiguration()
        {
            StringPrefixes = new[] { "!" }
        };

        private static string GetBotToken()
        {
            return ConfigurationManager.AppSettings["BotToken"];
        }

    }
}