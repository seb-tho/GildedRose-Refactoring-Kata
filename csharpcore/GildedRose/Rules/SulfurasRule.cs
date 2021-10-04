using GildedRoseKata;

namespace GildedRose.Rules
{
    public class SulfurasRule : RuleBase
    {
        protected override Item AdjustSellIn(Item item)
        {
            return item;
        }
    }
}
