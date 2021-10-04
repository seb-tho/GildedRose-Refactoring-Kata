using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Rules
{
    public abstract class RuleBase: IRule
    {
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
