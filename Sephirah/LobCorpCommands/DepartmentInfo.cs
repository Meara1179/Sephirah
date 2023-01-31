using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.LobCorpCommands
{
    public class DepartmentInfo : Application​Command​Module
    {
        [SlashCommand("DepartmentInfo", "[ALPHA] Information on a specific Department.")]
        public async Task DepartmentInfoSlash(InteractionContext ctx, [Option("Name", "The name of the Department or Sephirah")] string name)
        {
            var interaction = new DiscordInteractionResponseBuilder();

            switch (name.ToLower())
            {
                case "control":
                case "malkuth":
                    interaction = ControlEmbedBuilder();
                    break;
            }

            await ctx.CreateResponseAsync(interaction);
        }

        private DiscordInteractionResponseBuilder ControlEmbedBuilder()
        {
            var interaction = new DiscordInteractionResponseBuilder();
            FileStream image = new FileStream(@"Images\Sephirah\MalkuthPortrait.png", FileMode.Open, FileAccess.Read, FileShare.Read);

            interaction.AddFile(image);

            var thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
            {
                Url = "attachment://MalkuthPortrait.png"
            };
            var embed = new DiscordEmbedBuilder()
            {
                Title = "Control Department",
                Description = "**Malkuth**",
                Thumbnail = thumbnail,
                Color = DiscordColor.Orange
            };

            embed.AddField("Team Description", "> \"The Control Team monitors the employees and Abnormalities and plans the best course of action. " +
                "They give immediate orders to other employees while watching the CCTV feeds. " +
                "They tend to be quite bossy and assertive, making them unpopular with other teams.\"");
            embed.AddField("Department Fucntions", "> Clerks: Increases Movement Speed of all the employees in the facility by +1/3/5.\n" +
                "> Continued Service: Increases the Movement Speed of the respective Agent by +3/5/7/10");
            embed.AddField("TT2 Protocol:", "Unlock the 1.5x and 2x speed adjustment.\n\n \"You can speed up your management up to 2x using the TT2 Acceleration Protocol.\"", true);
            embed.AddField("Joint Command:", "Allow Agents to work in other departments where they aren't initially assigned.\n\n" +
                "\"Joint Command enables your to give cross-divisional work orders between departments.\"", true);
            embed.AddField("Summon Call:",
                "Unlocks a button for each department, next to the Regenerator Healing Gauge, that when pressed, orders all Agents of that department to return to the main room. This current move orders to those employees." +
                "\n\n\"Provide beepers to employees to have them return to their departments.\"", true);

            embed.AddField("Missions", "\u200b");
            embed.AddField("\"You Can Do This!\"", "\"Manager, don't forget that your primary goal is harvesting energy from the Abnormalities. It is the most important function of the company. Don't disappoint me!\"\n\n" +
                "\"Complete Abnormality work 3 times\"");
            embed.AddField("\"Semper Fi\"", "\"Your job is not just keeping the Abnormalities in control. You need to make them happy so they will produce as many as PE-Boxes. Everything else is secondary.\"\n\n" +
                "\"Complete work 4 times with a result of Good or higher\"");
            embed.AddField("\"Suppress Berserking\"", "\"As you may know, this facility isn’t that stable. We were only able to contain Abnormalities in containment units because we momentarily " +
                "released their suppressed power before the work began. However, suppression becomes unstable as time goes by and eventually some Abnormalities go into a meltdown.\"\n\n" +
                "\"Complete a Qliphoth Meltdown containment unit job 8 times\"");
            embed.AddField("\"At Dusk\"", "\"As the Deterrence of the facility becomes weaker and more Abnormalities become agitated, Abnormalities called Ordeals that could not be held down will go into a rampage. " +
                "Like now. Can you calm the employees down by suppressing one of Ordeals that show up at dusk? I will go help you soon.\"\n\n" +
                "\"Complete Ordeal of Dusk\"");

            interaction.AddEmbed(embed);

            return interaction;
        }
    }
}
