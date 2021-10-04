using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        #region TestData
        private const string REGULAR_ITEM = "RegularItem";
        private const string REGULAR_ITEM_PASSED_SELL_IN = "RegularItemPassedSellIn";
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGEPASS = "Backstage passes to a TAFKAL80ETC concert";
        private const string CONJURED = "Conjured Mana Cake";

        public static IEnumerable<object[]> GetRegularItems()
        {
            return new List<object[]>
            {
                new object[] { new List<Item> { new Item { Name = REGULAR_ITEM, SellIn = 20, Quality = 40 } } }
            };
        }

        public static IEnumerable<object[]> GetRegularItemsPassedSellIn()
        {
            return new List<object[]>
            {
                new object[] { new List<Item> { new Item { Name = REGULAR_ITEM_PASSED_SELL_IN, SellIn = 0, Quality = 40 } } }
            };
        }

        public static IEnumerable<object[]> GetMixedItems()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = REGULAR_ITEM, SellIn = 10, Quality = 20},
                new Item {Name = AGED_BRIE, SellIn = 2, Quality = 0},
                new Item {Name = REGULAR_ITEM, SellIn = 5, Quality = 7},
                new Item {Name = SULFURAS, SellIn = 0, Quality = 80},
                new Item {Name = SULFURAS, SellIn = -1, Quality = 80},
                new Item
                {
                    Name = BACKSTAGEPASS,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = BACKSTAGEPASS,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = BACKSTAGEPASS,
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = CONJURED, SellIn = 3, Quality = 6}
            };

            return new List<object[]>
            {
                new object[] { Items }

            };
        }

        public static IEnumerable<object[]> GetMixedItemsExceptSulfuras()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = REGULAR_ITEM, SellIn = 10, Quality = 20},
                new Item {Name = REGULAR_ITEM, SellIn = 5, Quality = 7},
                new Item {Name = AGED_BRIE, SellIn = 2, Quality = 0},
                new Item
                {
                    Name = BACKSTAGEPASS,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = BACKSTAGEPASS,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = BACKSTAGEPASS,
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = CONJURED, SellIn = 3, Quality = 6}
            };

            return new List<object[]>
            {
                new object[] { Items }

            };
        }
        public static IEnumerable<object[]> GetAgedBrie()
        {
            return new List<object[]>
            {
                new object[] { new List<Item> { new Item { Name = AGED_BRIE, SellIn = 20, Quality = 40 } } }
            };
        }

        public static IEnumerable<object[]> GetSulfuras()
        {
            return new List<object[]>
            {
                new object[] { new List<Item> { new Item { Name = SULFURAS, SellIn = 20, Quality = 80 } } }
            };
        }

        public static IEnumerable<object[]> GetBackstagePassSellIn10OrLess()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<Item>
                    {
                        new Item { Name = BACKSTAGEPASS, SellIn = 10, Quality = 20 },
                        new Item { Name = BACKSTAGEPASS, SellIn = 6, Quality = 20 }
                    }
                }
            };
        }

        public static IEnumerable<object[]> GetBackstagePassSellIn5OrLess()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<Item>
                    {
                        new Item { Name = BACKSTAGEPASS, SellIn = 5, Quality = 20 },
                        new Item { Name = BACKSTAGEPASS, SellIn = 2, Quality = 20 }
                    }
                }
            };
        }

        public static IEnumerable<object[]> GetBackstagePassAfterConcert()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<Item>
                    {
                        new Item { Name = BACKSTAGEPASS, SellIn = 0, Quality = 20 }
                    }
                }
            };
        }
        #endregion

        [Theory]
        [MemberData(nameof(GetRegularItems))]
        public void UpdateQuality_WithRegularItem_LowersSellInBy1(List<Item> regularItem)
        {
            var app = new GildedRose(regularItem);
            app.UpdateQuality();
            Assert.Equal(19, regularItem[0].SellIn);
        }

        [Theory]
        [MemberData(nameof(GetRegularItems))]
        public void UpdateQuality_WithRegularItem_LowersQualityBy1(List<Item> regularItem)
        {
            var app = new GildedRose(regularItem);
            app.UpdateQuality();
            Assert.Equal(39, regularItem[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetRegularItemsPassedSellIn))]
        public void UpdateQuality_WithRegularItemPassedSellIn_LowersQualityBy2(List<Item> regularItem)
        {
            var app = new GildedRose(regularItem);
            app.UpdateQuality();
            Assert.Equal(38, regularItem[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetMixedItems))]
        public void UpdateQuality_QualityOfItem_IsNeverNegative(List<Item> mixedItems)
        {
            var app = new GildedRose(mixedItems);
            for (int i = 0; i < 51; i++)
            {
                app.UpdateQuality();
            }

            foreach (var item in mixedItems)
            {
                Assert.False(item.Quality < 0);
            }

        }

        [Theory]
        [MemberData(nameof(GetAgedBrie))]
        public void UpdateQuality_WithAgedBrie_IncreasesQuality(List<Item> agedBrie)
        {
            var app = new GildedRose(agedBrie);
            app.UpdateQuality();
            Assert.Equal(41, agedBrie[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetMixedItemsExceptSulfuras))]
        public void UpdateQuality_QualityIsNeverMoreThan50(List<Item> mixedItemsExceptSulfuras)
        {
            var app = new GildedRose(mixedItemsExceptSulfuras);
            for (int i = 0; i < 51; i++)
            {
                app.UpdateQuality();
            }

            foreach (var item in mixedItemsExceptSulfuras)
            {
                Assert.False(item.Quality > 50);
            }
        }

        [Theory]
        [MemberData(nameof(GetSulfuras))]
        public void UpdateQuality_WithSulfuras_DoesNotAlterSellIn(List<Item> sulfuras)
        {
            var app = new GildedRose(sulfuras);
            app.UpdateQuality();
            Assert.Equal(20, sulfuras[0].SellIn);
        }

        [Theory]
        [MemberData(nameof(GetSulfuras))]
        public void UpdateQuality_WithSulfuras_DoesNotAlterQuality(List<Item> sulfuras)
        {
            var app = new GildedRose(sulfuras);
            app.UpdateQuality();
            Assert.Equal(80, sulfuras[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetBackstagePassSellIn10OrLess))]
        public void UpdateQuality_WithBackstagePass_IncreasesQualityBy2_WhenSellInIs10OrLess(List<Item> backstagePassSellIn10OrLess)
        {
            var app = new GildedRose(backstagePassSellIn10OrLess);
            app.UpdateQuality();
            Assert.Equal(22, backstagePassSellIn10OrLess[0].Quality);
            Assert.Equal(22, backstagePassSellIn10OrLess[1].Quality);
        }

        [Theory]
        [MemberData(nameof(GetBackstagePassSellIn5OrLess))]
        public void UpdateQuality_WithBackstagePass_IncreasesQualityBy3_WhenSellInIs5OrLess(List<Item> backstagePassSellIn5OrLess)
        {
            var app = new GildedRose(backstagePassSellIn5OrLess);
            app.UpdateQuality();
            Assert.Equal(23, backstagePassSellIn5OrLess[0].Quality);
            Assert.Equal(23, backstagePassSellIn5OrLess[1].Quality);
        }

        [Theory]
        [MemberData(nameof(GetBackstagePassAfterConcert))]
        public void UpdateQuality_WithBackstagePass_QualityEquals0AfterConcert(List<Item> backstagePassAfterConcert)
        {
            var app = new GildedRose(backstagePassAfterConcert);
            app.UpdateQuality();
            Assert.Equal(0, backstagePassAfterConcert[0].Quality);
        }
    }
}
