using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Sephirah.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.SlashCommands
{
    public class DebugCommands : Application​Command​Module
    {
        SqlCommands database = new SqlCommands();

        [RequireOwner]
        [SlashCommand("PingDatabase", "Pings the database to check connection status.")]
        public async Task PingDatabase(InteractionContext ctx)
        {
            bool databaseConnectionStatus = await database.PingDatabase();

            if (databaseConnectionStatus == true)
            {
                await ctx.CreateResponseAsync("The Memories of all the Sephirot have been Synchronized.");
            }
            else
            {
                await ctx.CreateResponseAsync("Connection with database has failed.");
            }
        }

        [RequireOwner]
        [SlashCommand("debug", "Debug Command")]
        public async Task DebugCommand(InteractionContext ctx)
        {
            LcAbnormality abnormality = new LcAbnormality();

            abnormality = await database.GetAbnormalityAsync("Standard Training-Dummy Rabbit");

            var embedBuilder = new DiscordEmbedBuilder
            {
                Title = abnormality.AbnoName,
                Description = abnormality.AbnoClassification,
                Color = DiscordColor.Red
            };

            embedBuilder.AddField("E.G.O Gift", abnormality.egoGift.EgoGiftName);
            embedBuilder.AddField("E.G.O Weapon", abnormality.egoWeapon.EgoWeaponName);
            embedBuilder.AddField("E.G.O Suit", abnormality.egoSuit.EgoSuitName);

            for (int i = 0; i < abnormality.ManageGuide.Count; i++)
            {
                embedBuilder.AddField($"Managerial Guidelines {i + 1}:", abnormality.ManageGuide[i].GuideText);
            }
            for (int i = 0; i < abnormality.AbnoStory.Count; i++)
            {
                embedBuilder.AddField("\u200b", abnormality.AbnoStory[i].AbnoStoryText);
            }

            await ctx.CreateResponseAsync(embedBuilder);
        }

        [RequireOwner]
        [SlashCommand("WelcomeToLC", "I bid you a warm welcome.")]
        public async Task WelcomeToLC(InteractionContext ctx)
        {
            var embedThumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = @"https://cdn.discordapp.com/attachments/726261273976897548/1067289352285196298/png-clipart-lobotomy-corporation-clash-of-clans-video-game-popular-indie-game-video-game.png",
                Height = 0,
                Width = 0
            };
            var embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Red,
                Title = "Welcome to Lobotomy Corporation",
                Thumbnail = embedThumbnail
            };

            embed.AddField("\u200b", "I give you a warm welcome to Lobotomy Corporation.");
            embed.AddField("Rules:", "> **- Don't be a dipshit.**\n> **- Don't cheat or steal other people's work.**\n> **- Pledge yourself to our Lord and Saviour Sean.**");
            embed.WithImageUrl(@"https://media.discordapp.net/attachments/726261273976897548/1067291886630490183/LobotomyCorp_DsXXAwjJUv.png?width=1193&height=671");

            await ctx.CreateResponseAsync(embed);
        }
    }
}
