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
        IList<Item> Items;

        public Logic(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != AGED_BRIE && item.Name != BACKSTAGEPASS)
                {
                    if (item.Quality > MIN_QUALTITY)
                    {
                        if (item.Name != SULFURAS)
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

                        if (item.Name == BACKSTAGEPASS)
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

                if (item.Name != SULFURAS)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < MIN_QUALTITY)
                {
                    if (item.Name != AGED_BRIE)
                    {
                        if (item.Name != BACKSTAGEPASS)
                        {
                            if (item.Quality > MIN_QUALTITY)
                            {
                                if (item.Name != SULFURAS)
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
    }
}
