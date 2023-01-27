using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Sephirah.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sephirah.SlashCommands
{
    public class SlashModule : Application​Command​Module
    {
        SqlCommands database = new SqlCommands();

        [SlashCommand("Abnormality", "[ALPHA] Search Abnormality by name.")]
        public async Task SearchAbnormality(InteractionContext ctx, [Option("Name", "The name of the Abnormality")] string name)
        {
            LcAbnormality abnormality= new LcAbnormality();

            // Standard Training-Dummy Rabbit
            abnormality = await database.GetAbnormalityAsync(name);

            await ctx.CreateResponseAsync(AbnoInfoEmbed(abnormality));

            ctx.Client.ComponentInteractionCreated += async (s, e) =>
            {
                switch (e.Id)
                {
                    case "manageGuide":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, AbnoGuideEmbed(abnormality));
                            break;
                        }
                    case "abnoInfo":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, AbnoInfoEmbed(abnormality));
                            break;
                        }
                    case "abnoStory":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, AbnoStoryEmbed(abnormality));
                            break;
                        }
                    case "abnoWeapon":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, EgoWeaponEmbed(abnormality.egoWeapon));
                            break;
                        }
                    case "abnoSuit":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, EgoSuitEmbed(abnormality.egoSuit));
                            break;
                        }
                }
            };
        }

        [SlashCommand("AbnormalityByClassification", "[ALPHA] Search Abnormality by classification.")]
        public async Task SearchAbnormalityByClassification(InteractionContext ctx, [Option("Classification", "The classification of the Abnormality")] string name)
        {
            LcAbnormality abnormality = new LcAbnormality();

            // Standard Training-Dummy Rabbit
            abnormality = await database.GetAbnormalityByClassificationAsync(name);

            await ctx.CreateResponseAsync(AbnoInfoEmbed(abnormality));

            ctx.Client.ComponentInteractionCreated += async (s, e) =>
            {
                switch (e.Id)
                {
                    case "manageGuide":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, AbnoGuideEmbed(abnormality));
                            break;
                        }
                    case "abnoInfo":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, AbnoInfoEmbed(abnormality));
                            break;
                        }
                    case "abnoStory":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, AbnoStoryEmbed(abnormality));
                            break;
                        }
                    case "abnoWeapon":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, EgoWeaponEmbed(abnormality.egoWeapon));
                            break;
                        }
                    case "abnoSuit":
                        {
                            var embed = e.Message.Embeds.First();
                            abnormality = await database.GetAbnormalityAsync(embed.Title);

                            e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, EgoSuitEmbed(abnormality.egoSuit));
                            break;
                        }
                }
            };
        }

        private StringBuilder ArrayStringAdder(List<int> iArray)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < iArray.Count; i++)
            {
                stringBuilder.AppendLine($"> **{iArray[i].ToString()}%**");
            }

            return stringBuilder;
        }

        private DiscordInteractionResponseBuilder AbnoInfoEmbed(LcAbnormality abnormality)
        {
            var buttons = new List<DiscordButtonComponent>();

            FileStream abnoImage = new FileStream(abnormality.AbnoImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            buttons.Add(new DiscordButtonComponent(ButtonStyle.Primary, "manageGuide", "Managerial Guidelines"));
            buttons.Add(new DiscordButtonComponent(ButtonStyle.Primary, "abnoStory", "Story"));

            if (abnormality.egoWeapon != null)
            {
                buttons.Add(new DiscordButtonComponent(ButtonStyle.Primary, "abnoWeapon", "E.G.O Weapon"));
            }
            if (abnormality.egoSuit != null)
            {
                buttons.Add(new DiscordButtonComponent(ButtonStyle.Primary, "abnoSuit", "E.G.O Suit"));
            }

            var embedThumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = $"attachment://{Path.GetFileName(abnormality.AbnoImagePath)}",
                Height = 0,
                Width = 0
            };

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
            {
                Color = EmbedColourPicker(abnormality),
                Title = abnormality.AbnoName,
                Description = abnormality.AbnoClassification,
                Thumbnail = embedThumbnail
            };

            embedBuilder.AddField(abnormality.AbnoRiskLevel, $"**Max E-Boxes: {abnormality.MaxEnkBoxes}**", false);

            embedBuilder.AddField("Good Work Result:", $"> **{abnormality.OutcomeGoodRange}**", true);
            embedBuilder.AddField("Normal Work Result:", $"> **{abnormality.OutcomeNormalRange}**", true);
            embedBuilder.AddField("Bad Work Result:", $"> **{abnormality.OutcomeBadRange}**", true);

            embedBuilder.AddField("Instinct:", ArrayStringAdder(abnormality.WorkListInstinct).ToString(), true);
            embedBuilder.AddField("Insight:", ArrayStringAdder(abnormality.WorkListInsight).ToString(), true);
            embedBuilder.AddField("Attachment:", ArrayStringAdder(abnormality.WorkListAttachment).ToString(), true);
            embedBuilder.AddField("Repression:", ArrayStringAdder(abnormality.WorkListRepression).ToString(), true);

            if (abnormality.MaxQliphothCount == 0)
            {
                embedBuilder.AddField("Max Qliphoth Count: ", $"> **Non-Escaping Entity**");
            }
            else
            {
                embedBuilder.AddField("Max Qliphoth Count: ", $"> **{abnormality.MaxQliphothCount.ToString()}**");
            }

            embedBuilder.AddField("Abnormality Defensive Statistics:", $"> **Red: {abnormality.DefenseRed.ToString()}**\n> **White: {abnormality.DefenseWhite.ToString()}**\n" +
                $"> **Black: {abnormality.DefenseBlack}**\n> **Pale: {abnormality.DefensePale}**");

            if (abnormality.egoGift != null)
            {
                embedBuilder.AddField("E.G.O Gift:", $"> **{abnormality.egoGift.EgoGiftName}**\n > **Slot: {abnormality.egoGift.GiftSlot}**\n" +
                    $"> **Stats: {abnormality.egoGift.GiftStats}**\n > **Ability: {abnormality.egoGift.GiftAbilities}**", true);
            }
            else
            {
                embedBuilder.AddField("E.G.O Gift:", $"> **None**", true);
            }

            if (abnormality.egoWeapon != null)
            {
                embedBuilder.AddField("E.G.O Weapon:", $"> **{abnormality.egoWeapon.EgoWeaponName}**\n > **{abnormality.egoWeapon.EgoWeaponRiskLevel}**\n" +
                    $" > **Damage Type: {abnormality.egoWeapon.DamageType}**\n > **Damage: {abnormality.egoWeapon.DamageRange}**\n" +
                    $" > **Speed: {abnormality.egoWeapon.AttackSpeed}**\n > **Range: {abnormality.egoWeapon.AttackRange}**", true);
            }
            else
            {
                embedBuilder.AddField("E.G.O Weapon:", "> **None**", true);
            }

            if (abnormality.egoSuit != null)
            {
                embedBuilder.AddField("E.G.O Suit:", $"> **{abnormality.egoSuit.EgoSuitName}**\n > **{abnormality.egoSuit.EgoSuitRiskLevel}**\n" +
                    $" > **Red Resistance: {abnormality.egoSuit.SuitDefenseRed.ToString()}**\n > **White Resistance: {abnormality.egoSuit.SuitDefenseWhite.ToString()}**\n" +
                    $" > **Black Resistance: {abnormality.egoSuit.SuitDefenseBlack.ToString()}**\n > **Pale Resistance: {abnormality.egoSuit.SuitDefensePale.ToString()}**", false);
            }
            else
            {
                embedBuilder.AddField("E.G.O Suit:", "> **None**", false);
            }

            var response = new DiscordInteractionResponseBuilder();

            response.AddEmbed(embedBuilder);
            response.AddFile(abnoImage);
            response.AddComponents(buttons);

            return response;
        }

        private DiscordInteractionResponseBuilder AbnoGuideEmbed(LcAbnormality abnormality)
        {
            FileStream abnoImage = new FileStream(abnormality.AbnoImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            var embedThumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = $"attachment://{Path.GetFileName(abnormality.AbnoImagePath)}",
                Height = 0,
                Width = 0
            };

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
            {
                Color = EmbedColourPicker(abnormality),
                Title = abnormality.AbnoName,
                Description = abnormality.AbnoClassification,
                Thumbnail = embedThumbnail
            };

            for (int i = 0; i < abnormality.ManageGuide.Count; i++)
            {
                embedBuilder.AddField($"Managerial Guidelines {i + 1}:", abnormality.ManageGuide[i].GuideText);
            }

            var response = new DiscordInteractionResponseBuilder();

            response.AddEmbed(embedBuilder);
            response.AddFile(abnoImage);
            response.AddComponents(new DiscordButtonComponent(ButtonStyle.Primary, "abnoInfo", "Abnormality Information"));

            return response;
        }

        private DiscordInteractionResponseBuilder AbnoStoryEmbed(LcAbnormality abnormality)
        {
            FileStream abnoImage = new FileStream(abnormality.AbnoImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            var embedThumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = $"attachment://{Path.GetFileName(abnormality.AbnoImagePath)}",
                Height = 0,
                Width = 0
            };

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
            {
                Color = EmbedColourPicker(abnormality),
                Title = abnormality.AbnoName,
                Description = abnormality.AbnoClassification,
                Thumbnail = embedThumbnail
            };

            for (int i = 0; i < abnormality.AbnoStory.Count; i++)
            {
                embedBuilder.AddField("\u200b", abnormality.AbnoStory[i].AbnoStoryText);
            }

            var response = new DiscordInteractionResponseBuilder();

            response.AddEmbed(embedBuilder);
            response.AddFile(abnoImage);
            response.AddComponents(new DiscordButtonComponent(ButtonStyle.Primary, "abnoInfo", "Abnormality Information"));

            return response;
        }

        private DiscordInteractionResponseBuilder EgoWeaponEmbed(EgoWeapon weapon)
        {
            FileStream egoWeaponImage = new FileStream(weapon.EgoWeaponImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            var embedThumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = $"attachment://{Path.GetFileName(weapon.EgoWeaponImagePath)}",
                Height = 0,
                Width = 0
            };

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
            {
                Color = EmbedColourPicker(weapon),
                Title = weapon.EgoWeaponName,
                Description = $"**{weapon.EgoWeaponRiskLevel}**",
                Thumbnail = embedThumbnail
            };

            embedBuilder.AddField("Damage Type:",$"> **{weapon.DamageType}**");
            embedBuilder.AddField("Damage:", $"> **{weapon.DamageRange}**");
            embedBuilder.AddField("Attack Speed: ", $"> **{weapon.AttackSpeed}**");
            embedBuilder.AddField("Attack Range: ", $"> **{weapon.AttackRange}**");

            var response = new DiscordInteractionResponseBuilder();

            response.AddEmbed(embedBuilder);
            response.AddFile(egoWeaponImage);
            response.AddComponents(new DiscordButtonComponent(ButtonStyle.Primary, "abnoInfo", "Abnormality Information"));

            return response;
        }

        private DiscordInteractionResponseBuilder EgoSuitEmbed(EgoSuit suit)
        {
            FileStream egoSuitImage = new FileStream(suit.EgoSuitImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            var embedThumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = $"attachment://{Path.GetFileName(suit.EgoSuitImagePath)}",
                Height = 0,
                Width = 0
            };

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
            {
                Color = EmbedColourPicker(suit),
                Title = suit.EgoSuitName,
                Description = $"**{suit.EgoSuitRiskLevel}**",
                Thumbnail = embedThumbnail
            };

            embedBuilder.AddField("E.G.O Suit Defensive Statistics:", $" > **Red Resistance: {suit.SuitDefenseRed.ToString()}**\n" +
                $" > **White Resistance: {suit.SuitDefenseWhite.ToString()}**\n" +
                    $" > **Black Resistance: {suit.SuitDefenseBlack.ToString()}**\n > **Pale Resistance: {suit.SuitDefensePale.ToString()}**", false);

            var response = new DiscordInteractionResponseBuilder();

            response.AddEmbed(embedBuilder);
            response.AddFile(egoSuitImage);
            response.AddComponents(new DiscordButtonComponent(ButtonStyle.Primary, "abnoInfo", "Abnormality Information"));

            return response;
        }

        #region Risk Colour Picker
        private DiscordColor EmbedColourPicker(LcAbnormality abno)
        {
            if (abno.AbnoRiskLevel.Contains("ALEPH"))
            {
                return DiscordColor.Red;
            }
            else if (abno.AbnoRiskLevel.Contains("WAW"))
            {
                return DiscordColor.Purple;
            }
            else if (abno.AbnoRiskLevel.Contains("HE"))
            {
                return DiscordColor.Yellow;
            }
            else if (abno.AbnoRiskLevel.Contains("TETH"))
            {
                return DiscordColor.Blue;
            }
            else if (abno.AbnoRiskLevel.Contains("ZAYIN"))
            {
                return DiscordColor.Green;
            }
            else
            {
                return DiscordColor.Gray;
            }
        }
        private DiscordColor EmbedColourPicker(EgoWeapon weapon)
        {
            if (weapon.EgoWeaponRiskLevel.Contains("ALEPH"))
            {
                return DiscordColor.Red;
            }
            else if (weapon.EgoWeaponRiskLevel.Contains("WAW"))
            {
                return DiscordColor.Purple;
            }
            else if (weapon.EgoWeaponRiskLevel.Contains("HE"))
            {
                return DiscordColor.Yellow;
            }
            else if (weapon.EgoWeaponRiskLevel.Contains("TETH"))
            {
                return DiscordColor.Blue;
            }
            else if (weapon.EgoWeaponRiskLevel.Contains("ZAYIN"))
            {
                return DiscordColor.Green;
            }
            else
            {
                return DiscordColor.Gray;
            }
        }
        private DiscordColor EmbedColourPicker(EgoSuit suit)
        {
            if (suit.EgoSuitRiskLevel.Contains("ALEPH"))
            {
                return DiscordColor.Red;
            }
            else if (suit.EgoSuitRiskLevel.Contains("WAW"))
            {
                return DiscordColor.Purple;
            }
            else if (suit.EgoSuitRiskLevel.Contains("HE"))
            {
                return DiscordColor.Yellow;
            }
            else if (suit.EgoSuitRiskLevel.Contains("TETH"))
            {
                return DiscordColor.Blue;
            }
            else if (suit.EgoSuitRiskLevel.Contains("ZAYIN"))
            {
                return DiscordColor.Green;
            }
            else
            {
                return DiscordColor.Gray;
            }
        }
        #endregion
    }
}
