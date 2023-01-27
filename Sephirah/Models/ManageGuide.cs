using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.Models
{
    public class ManageGuide
    {
        public int AbnoID { get; set; }
        public int GuideOrder { get; set; }
        public string GuideText { get; set; }
        public string GuideAbnoName { get; set; }

        public ManageGuide() 
        {
        
        }

        public ManageGuide(int abnoID, int guideOrder, string guideText, string guideAbnoName)
        {
            AbnoID = abnoID;
            GuideOrder = guideOrder;
            GuideText = guideText;
            GuideAbnoName = guideAbnoName;
        }
    }
}
