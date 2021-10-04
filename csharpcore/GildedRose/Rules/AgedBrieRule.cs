using GildedRoseKata;

namespace GildedRose.Rules
{
    public class AgedBrieRule : RuleBase
    {
        public override Item ApplyRule(Item item)
        {
            item.Quality++;
            if (item.SellIn <= 0)
                item.Quality++;

            return item;
        }
    }
}
