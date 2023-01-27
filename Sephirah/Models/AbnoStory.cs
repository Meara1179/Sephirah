using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.Models
{
    public class AbnoStory
    {
        public int AbnoID { get; set; }
        public int AbnoStoryOrder {  get; set; }
        public string AbnoStoryText { get; set; }
        public string StoryAbnoName { get; set; }

        public AbnoStory() 
        {

        }

        public AbnoStory(int abnoID, int abnoStoryOrder, string abnoStoryText, string storyAbnoName)
        {
            AbnoID = abnoID;
            AbnoStoryOrder = abnoStoryOrder;
            AbnoStoryText = abnoStoryText;
            StoryAbnoName = storyAbnoName;
        }
    }
}
