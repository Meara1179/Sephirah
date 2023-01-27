using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.Models
{
    public class EgoGift
    {
        public int AbnoID { get; set; }
        public string EgoGiftName { get; set; }
        public string EgoGiftAbnoName { get; set; }
        public string EgoGiftImagePath { get; set; }

        public bool IsSpecialObtained { get; set; }
        public string SpecialObtainMethod { get; set; }
        public int GiftDropChance { get; set; }

        public string GiftSlot { get; set; }

        public string GiftStats { get; set; }
        public string GiftAbilities { get; set; }

        public EgoGift()
        {

        }

        public EgoGift(int abnoID, string egoGiftName,string egoGiftAbnoName, string egoGiftImagePath, bool isSpecialObtained, string specialObtainMethod, 
            int giftDropChance, string giftSlot, string giftStats, string giftAbilities)
        {
            AbnoID = abnoID;
            EgoGiftName = egoGiftName;
            EgoGiftAbnoName = egoGiftAbnoName;
            EgoGiftImagePath = egoGiftImagePath;
            IsSpecialObtained = isSpecialObtained;
            SpecialObtainMethod = specialObtainMethod;
            GiftDropChance = giftDropChance;
            GiftSlot = giftSlot;
            GiftStats = giftStats;
            GiftAbilities = giftAbilities;
        }
    }
}
