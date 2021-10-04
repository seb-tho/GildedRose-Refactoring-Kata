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
                if (IsRegularItem(item) && item.Quality > MIN_QUALTITY)
                {
                    item.Quality--;
                }

                if (IsAgedBrie(item) && item.Quality < MAX_QUALITY)
                {
                    item.Quality++;
                }

                else
                {
                    if (item.Quality < MAX_QUALITY)
                    {
                        item.Quality++;

                        if (IsBackstagepass(item))
                        {
                            if (item.SellIn < BACKSTAGEPASS_THRESHOLD_1)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < BACKSTAGEPASS_THRESHOLD_2)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (!IsSulfuras(item))
                {
                    item.SellIn--;
                }

                if (item.SellIn < MIN_QUALTITY)
                {

                    if (!IsBackstagepass(item))
                    {
                        if (item.Quality > MIN_QUALTITY)
                        {
                            if (!IsSulfuras(item))
                            {
                                item.Quality--;
                            }
                        }

                        item.Quality -= item.Quality;

                    }
                    else
                    {
                        if (item.Quality < MAX_QUALITY)
                        {
                            item.Quality++;
                        }
                    }
                }
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
