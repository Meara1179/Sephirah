using MySqlConnector;
using Sephirah.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah
{
    public class SqlCommands
    {
        public async Task<EgoGift> GetEgoGiftAsync(string name)
        {
            EgoGift egoGift = new EgoGift();

            try
            {
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM egoGifts WHERE EgoGiftAbnoName = '{name}';", connection);

                await using var reader = await command.ExecuteReaderAsync() as MySqlDataReader;

                while (await reader.ReadAsync())
                {
                    int abnoID = reader.GetInt32(0);
                    string egoGiftName = reader.GetString(1);
                    string egoGiftAbnoName = reader.GetString(2);
                    string egoGiftImagePath = reader.GetString(3);
                    bool IsSpecialObtained = reader.GetBoolean(4);
                    string SpecialObtainMethod = reader.GetString(5);
                    int giftDropChance = reader.GetInt32(6);
                    string giftSlot = reader.GetString(7);
                    string giftStats = reader.GetString(8);
                    string giftAbilities = reader.GetString(9);

                    egoGift = new EgoGift(abnoID, egoGiftName, egoGiftAbnoName, egoGiftImagePath, IsSpecialObtained, SpecialObtainMethod,
                         giftDropChance, giftSlot, giftStats, giftAbilities);
                }

                return egoGift;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new EgoGift();
            }
        }

        public async Task<EgoWeapon> GetEgoWeaponAsync(string name)
        {
            EgoWeapon egoWeapon = new EgoWeapon();

            try
            {
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM egoweapons WHERE EgoWeaponAbnoName = '{name}';", connection);

                await using var reader = await command.ExecuteReaderAsync() as MySqlDataReader;

                while (await reader.ReadAsync())
                {
                    int abnoID = reader.GetInt32(0);
                    string egoWeaponName = reader.GetString(1);
                    string egoWeaponAbnoName = reader.GetString(2);
                    string egoWeaponRiskLevel = reader.GetString(3);
                    string egoWeaponImagePath = reader.GetString(4);
                    string damageType = reader.GetString(5);
                    string damageRange = reader.GetString(6);
                    string attackSpeed = reader.GetString(7);
                    string attackRange = reader.GetString(8);
                    string egoWeaponDescription = reader.GetString(9);
                    string egoWeaponAbility = reader.GetString(10);

                    egoWeapon = new EgoWeapon(abnoID, egoWeaponName, egoWeaponAbnoName, egoWeaponRiskLevel, egoWeaponImagePath, damageType,
                         damageRange, attackSpeed, attackRange, egoWeaponDescription, egoWeaponAbility);
                }

                return egoWeapon;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new EgoWeapon();
            }
        }

        public async Task<EgoSuit> GetEgoSuitAsync(string name)
        {
            EgoSuit egoSuit = new EgoSuit();

            try
            {
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM egoSuits WHERE EgoSuitAbnoName = '{name}';", connection);

                await using var reader = await command.ExecuteReaderAsync() as MySqlDataReader;

                while (await reader.ReadAsync())
                {
                    int abnoID = reader.GetInt32(0);
                    string egoSuitName = reader.GetString(1);
                    string egoSuitAbnoName = reader.GetString(2);
                    string egoSuitRiskLevel = reader.GetString(3);
                    string egoSuitImagePath = reader.GetString(4);
                    double suitDefenseRed = reader.GetDouble(5);
                    double suitDefenseWhite = reader.GetDouble(6);
                    double suitDefenseBlack = reader.GetDouble(7);
                    double suitDefensePale = reader.GetDouble(8);
                    string egoSuitDescription = reader.GetString(9);
                    string egoSuitAbility = reader.GetString(10);

                    egoSuit = new EgoSuit(abnoID, egoSuitName, egoSuitAbnoName, egoSuitRiskLevel, egoSuitImagePath,
                        suitDefenseRed, suitDefenseWhite, suitDefenseBlack, suitDefensePale, egoSuitDescription, egoSuitAbility);

                }
                return egoSuit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new EgoSuit();
            }
        }

        public async Task<List<ManageGuide>> GetManageGuideAsync(string name)
        {
            List<ManageGuide> guides = new List<ManageGuide>();

            try
            {
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM manageguidelist WHERE GuideAbnoName = '{name}';", connection);

                await using var reader = await command.ExecuteReaderAsync() as MySqlDataReader;

                while (await reader.ReadAsync())
                {
                    int abnoID = reader.GetInt32(0);
                    int guideOrder = reader.GetInt32(1);
                    string guideText = reader.GetString(2);
                    string guideAbnoName = reader.GetString(3);

                    guides.Add(new ManageGuide(abnoID, guideOrder, guideText, guideAbnoName));

                }
                return guides;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return guides;
            }
        }

        public async Task<List<AbnoStory>> GetAbnoStoryAsync(string name)
        {
            List<AbnoStory> abnoStories = new List<AbnoStory>();

            try
            {
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM abnostorylist WHERE StoryAbnoName = '{name}';", connection);

                await using var reader = await command.ExecuteReaderAsync() as MySqlDataReader;

                while (await reader.ReadAsync())
                {
                    int abnoID = reader.GetInt32(0);
                    int abnoStoryOrder = reader.GetInt32(1);
                    string abnoStoryText = reader.GetString(2);
                    string storyAbnoName = reader.GetString(3);

                    abnoStories.Add(new AbnoStory(abnoID, abnoStoryOrder, abnoStoryText, storyAbnoName));

                }
                return abnoStories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return abnoStories;
            }
        }

        public async Task<LcAbnormality> GetAbnormalityAsync(string name)
        {
            LcAbnormality abnormality = new LcAbnormality();

            try
            {
                // Gets the objects that are going into the Abnormality object.
                var egoGiftTask = GetEgoGiftAsync(name);
                var egoWeaponTask = GetEgoWeaponAsync(name);
                var egoSuitTask = GetEgoSuitAsync(name);
                var manageGuideTask = GetManageGuideAsync(name);
                var abnoStoryTask = GetAbnoStoryAsync(name);

                await Task.WhenAll(egoGiftTask, egoWeaponTask, egoSuitTask, manageGuideTask, abnoStoryTask);

                var egoGift = await egoGiftTask;
                var egoWeapon = await egoWeaponTask;
                var egoSuit = await egoSuitTask;
                var manageGuide = await manageGuideTask;
                var abnoStory = await abnoStoryTask;

                LcAbnormality abno = new LcAbnormality();

                // Retrieves Abnoramlity data from DB.
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM lcabnormalities WHERE AbnoName = '{name}';", connection);

                await using var reader = await command.ExecuteReaderAsync() as MySqlDataReader;

                while (await reader.ReadAsync())
                {
                    int abnoID = reader.GetInt32(0);
                    string abnoClassification = reader.GetString(1);
                    string abnoName = reader.GetString(2);
                    string abnoRiskLevel = reader.GetString(3);
                    string abnoImagePath = reader.GetString(4);
                    string workDamageType = reader.GetString(5);
                    string workDamageAmount = reader.GetString(6);
                    int maxEnkBoxes = reader.GetInt32(7);
                    string outcomeGoodRange = reader.GetString(8);
                    string outcomeNormalRange = reader.GetString(9);
                    string outcomeBadRange = reader.GetString(10);

                    string workListInstinctString = reader.GetString(11);
                    List<int> workListInstinct = new List<int>();
                    string[] instinctValues = workListInstinctString.Split(',');
                    foreach (var value in instinctValues)
                    {
                        workListInstinct.Add(int.Parse(value));
                    }

                    string workListInsightString = reader.GetString(12);
                    List<int> workListInsight = new List<int>();
                    string[] insightValue = workListInsightString.Split(',');
                    foreach (var value in insightValue)
                    {
                        workListInsight.Add(int.Parse(value));
                    }

                    string workListAttachmentString = reader.GetString(13);
                    List<int> workListAttachment = new List<int>();
                    string[] attachmentValue = workListAttachmentString.Split(',');
                    foreach (var value in attachmentValue)
                    {
                        workListAttachment.Add(int.Parse(value));
                    }

                    string workListRepressionString = reader.GetString(14);
                    List<int> workListRepression = new List<int>();
                    string[] repressionValue = workListRepressionString.Split(',');
                    foreach (var value in repressionValue)
                    {
                        workListRepression.Add(int.Parse(value));
                    }

                    int maxQliphothCount = reader.GetInt32(15);
                    double defenseRed = reader.GetDouble(16);
                    double defenseWhite = reader.GetDouble(17);
                    double defenseBlack = reader.GetDouble(18);
                    double defensePale = reader.GetDouble(19);
                    bool isTool = reader.GetBoolean(20);

                    if (isTool)
                    {
                        abno = new LcAbnormality(abnoID, abnoClassification, abnoName, abnoRiskLevel, abnoImagePath, manageGuide, abnoStory);
                    }
                    else
                    {
                        abno = new LcAbnormality(abnoID, abnoClassification, abnoName, abnoRiskLevel, abnoImagePath, workDamageType, workDamageAmount, 
                            maxEnkBoxes, outcomeGoodRange, outcomeNormalRange, outcomeBadRange, manageGuide, workListInstinct, workListInsight, 
                            workListAttachment, workListRepression, maxQliphothCount, defenseRed, defenseWhite, defenseBlack, defensePale, 
                            abnoStory, egoGift, egoWeapon, egoSuit);
                    }
                }
                return abno;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new LcAbnormality();
            }

        }

        public async Task<LcAbnormality> GetAbnormalityByClassificationAsync(string classifcation)
        {
            LcAbnormality abnormality = new LcAbnormality();
            string name = "0-00-00";

            try
            {
                await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
                await connection.OpenAsync();

                using var classicationCommand = new MySqlCommand($"SELECT * FROM lcabnormalities WHERE AbnoClassification = '{classifcation}';", connection);

                await using var classicationReader = await classicationCommand.ExecuteReaderAsync() as MySqlDataReader;

                while (await classicationReader.ReadAsync())
                {
                    name = classicationReader.GetString(2);
                }
            return await GetAbnormalityAsync(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new LcAbnormality();
            }

        }

        public async Task<bool> PingDatabase()
        {
            await using var connection = new MySqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"]);
            await connection.OpenAsync();

            return connection.Ping();
        }
    }
}
