using GildedRoseKata;

namespace GildedRose.Rules
{
    public class ConjuredRule : RuleBase
    {
        protected override Item AdjustQuality(Item item)
        {
            item.Quality -= 2;
            if (item.SellIn <= 0)
                item.Quality -= 2;
            item = GuardQualityBorders(item);
            return item;
        }
    }
}
