using GildedRoseKata;

namespace GildedRose.Rules
{
    public class BackStagePassRule: RuleBase
    {
        public const int BACKSTAGEPASS_THRESHOLD_1 = 11;
        public const int BACKSTAGEPASS_THRESHOLD_2 = 6;

        protected override Item AdjustQuality(Item item)
        {
            item.Quality++;

            if (item.SellIn < BACKSTAGEPASS_THRESHOLD_1)
            {
                item.Quality++;
            }

            if (item.SellIn < BACKSTAGEPASS_THRESHOLD_2)
            {
                item.Quality++;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            item = GuardQualityBorders(item);
            return item;
        }

    }
}
