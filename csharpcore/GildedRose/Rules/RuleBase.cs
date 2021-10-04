using GildedRoseKata;

namespace GildedRose.Rules
{
    public abstract class RuleBase: IRule
    {
        //I could have used a Quality class with max and min as props, maybe if the app were more complex. 
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALTITY = 0;
        protected virtual Item GuardQualityBorders(Item item)
        {
            if (item.Quality > MAX_QUALITY)
                item.Quality = MAX_QUALITY;

            if (item.Quality < MIN_QUALTITY)
                item.Quality = MIN_QUALTITY;

            return item;
        }

        protected virtual Item AdjustQuality(Item item) {
            return item;
        }

        protected virtual Item AdjustSellIn(Item item) {
            item.SellIn--;
            return item;
        }

        public Item ApplyRule(Item item)
        {
            item = AdjustQuality(item);            
            item = AdjustSellIn(item);
            return item;
        }
    }
}
