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
            for (var i = MIN_QUALTITY; i < Items.Count; i++)
            {
                if (Items[i].Name != AGED_BRIE && Items[i].Name != BACKSTAGEPASS)
                {
                    if (Items[i].Quality > MIN_QUALTITY)
                    {
                        if (Items[i].Name != SULFURAS)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < MAX_QUALITY)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BACKSTAGEPASS)
                        {
                            if (Items[i].SellIn < BACKSTAGEPASS_THRESHOLD_1)
                            {
                                if (Items[i].Quality < MAX_QUALITY)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < BACKSTAGEPASS_THRESHOLD_2)
                            {
                                if (Items[i].Quality < MAX_QUALITY)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SULFURAS)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < MIN_QUALTITY)
                {
                    if (Items[i].Name != AGED_BRIE)
                    {
                        if (Items[i].Name != BACKSTAGEPASS)
                        {
                            if (Items[i].Quality > MIN_QUALTITY)
                            {
                                if (Items[i].Name != SULFURAS)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < MAX_QUALITY)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
