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
                if (!IsAgedBrie(item) && !IsBackstagepass(item))
                {
                    if (item.Quality > MIN_QUALTITY)
                    {
                        if (!IsSulfuras(item))
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MAX_QUALITY)
                    {
                        item.Quality = item.Quality + 1;

                        if (IsBackstagepass(item))
                        {
                            if (item.SellIn < BACKSTAGEPASS_THRESHOLD_1)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < BACKSTAGEPASS_THRESHOLD_2)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!IsSulfuras(item))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < MIN_QUALTITY)
                {
                    if (!IsAgedBrie(item))
                    {
                        if (!IsBackstagepass(item))
                        {
                            if (item.Quality > MIN_QUALTITY)
                            {
                                if (!IsSulfuras(item))
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < MAX_QUALITY)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
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
