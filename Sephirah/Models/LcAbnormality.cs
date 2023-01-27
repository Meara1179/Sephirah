using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.Models
{
    public class LcAbnormality
    {
        public int AbnoID { get; set; }
        public string AbnoClassification { get; set; }
        public string AbnoName { get; set;}
        public string AbnoRiskLevel { get; set; }
        public string AbnoImagePath { get; set;}

        public string WorkDamageType { get; set; }
        public string WorkDamageAmount { get; set; }
        public int MaxEnkBoxes { get; set; }

        public string OutcomeGoodRange { get; set; }
        public string OutcomeNormalRange { get; set; }
        public string OutcomeBadRange { get; set; }

        public List<ManageGuide> ManageGuide { get; set; }

        public List<int> WorkListInstinct { get; set; }
        public List<int> WorkListInsight { get; set; }
        public List<int> WorkListAttachment { get; set; }
        public List<int> WorkListRepression { get; set; }

        public int MaxQliphothCount { get; set; }

        public double DefenseRed { get; set; }
        public double DefenseWhite { get; set; }
        public double DefenseBlack { get; set;}
        public double DefensePale { get; set; }

        public List<AbnoStory> AbnoStory { get; set; }

        public EgoGift egoGift { get; set; }
        public EgoWeapon egoWeapon { get; set; }
        public EgoSuit egoSuit { get; set; }

        public bool IsTool { get; set; } = false;

        public LcAbnormality()
        {

        }

        // Standard Abnormality
        public LcAbnormality(int abnoID, string abnoClassification, string abnoName, string abnoRiskLevel, string abnoImagePath, 
            string workDamageType, string workDamageAmount, int maxEnkBoxes, 
            string outcomeGoodRange, string outcomeNormalRange, string outcomeBadRange, 
            List<ManageGuide> manageGuide, List<int> workListInstinct, List<int> workListInsight, List<int> workListAttachment, List<int> workListRepression, 
            int maxQliphothCount, double defenseRed, double defenseWhite, double defenseBlack, double defensePale, List<AbnoStory> abnoStory, 
            EgoGift egoGift, EgoWeapon egoWeapon, EgoSuit egoSuit)
        {
            AbnoID = abnoID;
            AbnoClassification = abnoClassification;
            AbnoName = abnoName;
            AbnoRiskLevel = abnoRiskLevel;
            AbnoImagePath = abnoImagePath;
            WorkDamageType = workDamageType;
            WorkDamageAmount = workDamageAmount;
            MaxEnkBoxes = maxEnkBoxes;
            OutcomeGoodRange = outcomeGoodRange;
            OutcomeNormalRange = outcomeNormalRange;
            OutcomeBadRange = outcomeBadRange;
            ManageGuide = manageGuide;
            WorkListInstinct = workListInstinct;
            WorkListInsight = workListInsight;
            WorkListAttachment = workListAttachment;
            WorkListRepression = workListRepression;
            MaxQliphothCount = maxQliphothCount;
            DefenseRed = defenseRed;
            DefenseWhite = defenseWhite;
            DefenseBlack = defenseBlack;
            DefensePale = defensePale;
            AbnoStory = abnoStory;
            if (egoGift != null)
            {
                this.egoGift = egoGift;
            }
            if (egoWeapon != null)
            {
                this.egoWeapon = egoWeapon;
            }
            if (egoSuit != null)
            {
                this.egoSuit = egoSuit;
            }

        }
        /*
        // No Weapon or Suit
        public LcAbnormality(string abnoClassification, string abnoName, string abnoRiskLevel, string abnoImagePath,
            string workDamageType, string workDamageAmount, int maxEnkBoxes,
            string outcomeGoodRange, string outcomeNormalRange, string outcomeBadRange,
            List<string> manageGuide, List<int> workListInstinct, List<int> workListInsight, List<int> workListAttachment, List<int> workListRepression,
            int maxQliphothCount, double defenseRed, double defenseWhite, double defenseBlack, double defensePale, List<string> abnoStory,
            EgoGift egoGift)
        {
            AbnoClassification = abnoClassification;
            AbnoName = abnoName;
            AbnoRiskLevel = abnoRiskLevel;
            AbnoImagePath = abnoImagePath;
            WorkDamageType = workDamageType;
            WorkDamageAmount = workDamageAmount;
            MaxEnkBoxes = maxEnkBoxes;
            OutcomeGoodRange = outcomeGoodRange;
            OutcomeNormalRange = outcomeNormalRange;
            OutcomeBadRange = outcomeBadRange;
            ManageGuide = manageGuide;
            WorkListInstinct = workListInstinct;
            WorkListInsight = workListInsight;
            WorkListAttachment = workListAttachment;
            WorkListRepression = workListRepression;
            MaxQliphothCount = maxQliphothCount;
            DefenseRed = defenseRed;
            DefenseWhite = defenseWhite;
            DefenseBlack = defenseBlack;
            DefensePale = defensePale;
            AbnoStory = abnoStory;
            this.egoGift = egoGift;
        }

        // No Gift
        public LcAbnormality(string abnoClassification, string abnoName, string abnoRiskLevel, string abnoImagePath,
            string workDamageType, string workDamageAmount, int maxEnkBoxes,
            string outcomeGoodRange, string outcomeNormalRange, string outcomeBadRange,
            List<string> manageGuide, List<int> workListInstinct, List<int> workListInsight, List<int> workListAttachment, List<int> workListRepression,
            int maxQliphothCount, double defenseRed, double defenseWhite, double defenseBlack, double defensePale, List<string> abnoStory,
            EgoWeapon egoWeapon, EgoSuit egoSuit)
        {
            AbnoClassification = abnoClassification;
            AbnoName = abnoName;
            AbnoRiskLevel = abnoRiskLevel;
            AbnoImagePath = abnoImagePath;
            WorkDamageType = workDamageType;
            WorkDamageAmount = workDamageAmount;
            MaxEnkBoxes = maxEnkBoxes;
            OutcomeGoodRange = outcomeGoodRange;
            OutcomeNormalRange = outcomeNormalRange;
            OutcomeBadRange = outcomeBadRange;
            ManageGuide = manageGuide;
            WorkListInstinct = workListInstinct;
            WorkListInsight = workListInsight;
            WorkListAttachment = workListAttachment;
            WorkListRepression = workListRepression;
            MaxQliphothCount = maxQliphothCount;
            DefenseRed = defenseRed;
            DefenseWhite = defenseWhite;
            DefenseBlack = defenseBlack;
            DefensePale = defensePale;
            AbnoStory = abnoStory;
            this.egoWeapon = egoWeapon;
            this.egoSuit = egoSuit;
        }

        // No Suit
        public LcAbnormality(string abnoClassification, string abnoName, string abnoRiskLevel, string abnoImagePath,
            string workDamageType, string workDamageAmount, int maxEnkBoxes,
            string outcomeGoodRange, string outcomeNormalRange, string outcomeBadRange,
            List<string> manageGuide, List<int> workListInstinct, List<int> workListInsight, List<int> workListAttachment, List<int> workListRepression,
            int maxQliphothCount, double defenseRed, double defenseWhite, double defenseBlack, double defensePale, List<string> abnoStory,
            EgoGift egoGift, EgoWeapon egoWeapon)
        {
            AbnoClassification = abnoClassification;
            AbnoName = abnoName;
            AbnoRiskLevel = abnoRiskLevel;
            AbnoImagePath = abnoImagePath;
            WorkDamageType = workDamageType;
            WorkDamageAmount = workDamageAmount;
            MaxEnkBoxes = maxEnkBoxes;
            OutcomeGoodRange = outcomeGoodRange;
            OutcomeNormalRange = outcomeNormalRange;
            OutcomeBadRange = outcomeBadRange;
            ManageGuide = manageGuide;
            WorkListInstinct = workListInstinct;
            WorkListInsight = workListInsight;
            WorkListAttachment = workListAttachment;
            WorkListRepression = workListRepression;
            MaxQliphothCount = maxQliphothCount;
            DefenseRed = defenseRed;
            DefenseWhite = defenseWhite;
            DefenseBlack = defenseBlack;
            DefensePale = defensePale;
            AbnoStory = abnoStory;
            this.egoGift = egoGift;
            this.egoWeapon = egoWeapon;
        }

        // No Weapon
        public LcAbnormality(string abnoID, string abnoName, string abnoRiskLevel, string abnoImagePath,
            string workDamageType, string workDamageAmount, int maxEnkBoxes,
            string outcomeGoodRange, string outcomeNormalRange, string outcomeBadRange,
            List<string> manageGuide, List<int> workListInstinct, List<int> workListInsight, List<int> workListAttachment, List<int> workListRepression,
            int maxQliphothCount, double defenseRed, double defenseWhite, double defenseBlack, double defensePale, List<string> abnoStory,
            EgoGift egoGift, EgoSuit egoSuit)
        {
            AbnoClassification = abnoID;
            AbnoName = abnoName;
            AbnoRiskLevel = abnoRiskLevel;
            AbnoImagePath = abnoImagePath;
            WorkDamageType = workDamageType;
            WorkDamageAmount = workDamageAmount;
            MaxEnkBoxes = maxEnkBoxes;
            OutcomeGoodRange = outcomeGoodRange;
            OutcomeNormalRange = outcomeNormalRange;
            OutcomeBadRange = outcomeBadRange;
            ManageGuide = manageGuide;
            WorkListInstinct = workListInstinct;
            WorkListInsight = workListInsight;
            WorkListAttachment = workListAttachment;
            WorkListRepression = workListRepression;
            MaxQliphothCount = maxQliphothCount;
            DefenseRed = defenseRed;
            DefenseWhite = defenseWhite;
            DefenseBlack = defenseBlack;
            DefensePale = defensePale;
            AbnoStory = abnoStory;
            this.egoGift = egoGift;
            this.egoSuit = egoSuit;
        }
        */
        // Tool Abnormality
        public LcAbnormality(int abnoID, string abnoClassification, string abnoName, string abnoRiskLevel, string abnoImagePath, List<ManageGuide> manageGuide, List<AbnoStory> abnoStory)
        {
            IsTool = true;
            AbnoClassification = abnoClassification;
            AbnoName = abnoName;
            AbnoRiskLevel = abnoRiskLevel;
            AbnoImagePath = abnoImagePath;
            ManageGuide = manageGuide;
            AbnoStory = abnoStory;
        }
    }
}
