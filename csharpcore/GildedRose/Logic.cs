using GildedRose;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Logic
    {
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALTITY = 0;

        private readonly IList<Item> Items;
        private readonly RulesRepo RulesRepo;

        public Logic(IList<Item> items, RulesRepo rulesRepo)
        {
            Items = items;
            RulesRepo = rulesRepo;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
  
                GuardQualityBorders(item);

                item.SellIn--;

            }
        }

        private static void GuardQualityBorders(Item item)
        {
            if (item.Quality > MAX_QUALITY)
                item.Quality = MAX_QUALITY;

            if (item.Quality < MIN_QUALTITY)
                item.Quality = MIN_QUALTITY;
        }

        private static bool IsRegularItem(Item item)
        {
            return !IsSulfuras(item) && !IsAgedBrie(item) && !IsBackstagepass(item);
        }

        private static bool IsSulfuras(Item item)
        {
            return item.Name == SULFURAS;
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == AGED_BRIE;
        }

        private static bool IsBackstagepass(Item item)
        {
            return item.Name == BACKSTAGEPASS;
        }
    }
}
