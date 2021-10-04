using GildedRoseKata;
using System.Collections.Generic;

namespace GildedRose
{
    public class RulesRepo
    {
        public const string AGED_BRIE = "Aged Brie";
        public const string BACKSTAGEPASS = "Backstage passes to a TAFKAL80ETC concert";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string CONJURED = "Conjured";


        public Dictionary<string, RuleBase> Rules { get; set; }

        public RulesRepo(IEnumerable<Item> items)
        {
            Rules = FillDictionary();

        }

        private Dictionary<string, RuleBase> FillDictionary()
        {
            Rules.Add(AGED_BRIE, new RuleBase());

        }
    }
}
