﻿using GildedRoseKata;

namespace GildedRose.Rules
{
    public class AgedBrieRule : RuleBase
    {
        protected override Item AdjustQuality(Item item)
        {
            item.Quality++;
            if (item.SellIn <= 0)
                item.Quality++;

            item = GuardQualityBorders(item);
            return item;
        }
    }
}