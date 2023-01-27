using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.Models
{
    public class EgoSuit
    {
        public int AbnoID { get; set; }
        public string EgoSuitName { get; set; }
        public string EgoSuitAbnoName { get; set; }
        public string EgoSuitRiskLevel { get; set; }
        public string EgoSuitImagePath { get; set; }

        public double SuitDefenseRed { get; set; }
        public double SuitDefenseWhite { get; set; }
        public double SuitDefenseBlack { get; set; }
        public double SuitDefensePale { get; set; }

        public string EgoSuitDescription { get; set; }
        public string EgoSuitAbility { get; set; }

        public EgoSuit()
        {

        }

        public EgoSuit(int abnoID, string egoSuitName, string egoSuitAbnoName, string egoSuitRiskLevel, string egoSuitImagePath,
            double suitDefenseRed, double suitDefenseWhite, double suitDefenseBlack, double suitDefensePale, string egoSuitDescription, string egoSuitAbility)
        {
            AbnoID = abnoID;
            EgoSuitName = egoSuitName;
            EgoSuitAbnoName = egoSuitAbnoName;
            EgoSuitRiskLevel = egoSuitRiskLevel;
            EgoSuitImagePath = egoSuitImagePath;
            SuitDefenseRed = suitDefenseRed;
            SuitDefenseWhite = suitDefenseWhite;
            SuitDefenseBlack = suitDefenseBlack;
            SuitDefensePale = suitDefensePale;
            EgoSuitDescription = egoSuitDescription;
            EgoSuitAbility = egoSuitAbility;
        }
    }
}
