using GildedRoseKata;

namespace GildedRose.Rules
{
    public class BackStagePassRule : IRule
    {
        public const int BACKSTAGEPASS_THRESHOLD_1 = 11;
        public const int BACKSTAGEPASS_THRESHOLD_2 = 6;

        public Item ApplyRule(Item item)
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
            return item;
        }

    }
}
