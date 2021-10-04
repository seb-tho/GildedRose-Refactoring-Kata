using GildedRoseKata;

namespace GildedRose.Rules
{
    public class SulfurasRule : RuleBase
    {
        protected override Item AdjustQuality(Item item)
        {
            return item;
        }

        protected override Item AdjustSellIn(Item item)
        {
            return item;
        }
    }
}
