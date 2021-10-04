using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Logic
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGEPASS = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALTITY = 0;
        private const int BACKSTAGEPASS_THRESHOLD_1 = 11;
        private const int BACKSTAGEPASS_THRESHOLD_2 = 6;
        readonly IList<Item> Items;

        public Logic(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsSulfuras(item))
                    continue;


                if (IsRegularItem(item) && item.Quality > MIN_QUALTITY)
                {
                    item.Quality--;
                    if (item.SellIn <= 0 && item.Quality > MIN_QUALTITY)
                        item.Quality--;
                }

                if (IsAgedBrie(item))
                {
                    item.Quality++;
                    if (item.SellIn <= 0)
                        item.Quality++;
                }

                if (IsBackstagepass(item) && item.Quality > MIN_QUALTITY)
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

                }

                if (item.Quality > MAX_QUALITY)
                    item.Quality = MAX_QUALITY;

                item.SellIn--;

            }
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
