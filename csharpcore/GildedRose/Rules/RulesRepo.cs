using GildedRose.Rules;
using System.Collections.Generic;

namespace GildedRose
{
    public class RulesRepo
    {
        public const string AGED_BRIE = "Aged Brie";
        public const string BACKSTAGEPASS = "Backstage passes to a TAFKAL80ETC concert";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string CONJURED = "Conjured";
        public const string REGULAR = "Regular";

        public Dictionary<string, IRule> Rules { get; set; }

        public RulesRepo()
        {
            Rules = FillDictionary();
        }

        private Dictionary<string, IRule> FillDictionary()
        {
            return new Dictionary<string, IRule>
            {
                { REGULAR, new RegularRule() },
                { AGED_BRIE, new AgedBrieRule() },
                { BACKSTAGEPASS, new BackStagePassRule() },
                { SULFURAS, new SulfurasRule() },
                { CONJURED, new ConjuredRule() }
            };
        }
    }
}
