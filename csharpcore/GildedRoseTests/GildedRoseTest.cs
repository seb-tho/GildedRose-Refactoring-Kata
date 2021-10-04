using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRose;

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
        private const string CONJURED_ITEM = "Conjured Apple Pie";

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
                new Item {Name = CONJURED_ITEM, SellIn = 3, Quality = 6}
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
                new Item {Name = CONJURED_ITEM, SellIn = 3, Quality = 6}
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
                        new Item { Name = BACKSTAGEPASS, SellIn = 1, Quality = 20 }
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

        public static IEnumerable<object[]> GetConjuredItems()
        {
            return new List<object[]>
            {
                new object[] { new List<Item> { new Item { Name = CONJURED_ITEM, SellIn = 20, Quality = 40 } } }
            };
        }

        public static IEnumerable<object[]> GetConjuredItemsPassedSellIn()
        {
            return new List<object[]>
            {
                new object[] { new List<Item> { new Item { Name = CONJURED_ITEM, SellIn = 0, Quality = 40 } } }
            };
        }

        #endregion

        [Theory]
        [MemberData(nameof(GetRegularItems))]
        public void UpdateQuality_WithRegularItem_LowersSellInBy1(List<Item> regularItem)
        {
            var logic = new Logic(regularItem, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(19, regularItem[0].SellIn);
        }

        [Theory]
        [MemberData(nameof(GetRegularItems))]
        public void UpdateQuality_WithRegularItem_LowersQualityBy1(List<Item> regularItem)
        {
            var logic = new Logic(regularItem, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(39, regularItem[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetRegularItemsPassedSellIn))]
        public void UpdateQuality_WithRegularItemPassedSellIn_LowersQualityBy2(List<Item> regularItem)
        {
            var logic = new Logic(regularItem, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(38, regularItem[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetMixedItems))]
        public void UpdateQuality_QualityOfItem_IsNeverNegative(List<Item> mixedItems)
        {
            var logic = new Logic(mixedItems, new RulesRepo());
            for (int i = 0; i < 51; i++)
            {
                logic.UpdateQuality();
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
            var logic = new Logic(agedBrie, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(41, agedBrie[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetMixedItemsExceptSulfuras))]
        public void UpdateQuality_QualityIsNeverMoreThan50(List<Item> mixedItemsExceptSulfuras)
        {
            var logic = new Logic(mixedItemsExceptSulfuras, new RulesRepo());
            for (int i = 0; i < 51; i++)
            {
                logic.UpdateQuality();
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
            var logic = new Logic(sulfuras, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(20, sulfuras[0].SellIn);
        }

        [Theory]
        [MemberData(nameof(GetSulfuras))]
        public void UpdateQuality_WithSulfuras_DoesNotAlterQuality(List<Item> sulfuras)
        {
            var logic = new Logic(sulfuras, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(80, sulfuras[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetBackstagePassSellIn10OrLess))]
        public void UpdateQuality_WithBackstagePass_IncreasesQualityBy2_WhenSellInIs10OrLess(List<Item> backstagePassSellIn10OrLess)
        {
            var logic = new Logic(backstagePassSellIn10OrLess, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(22, backstagePassSellIn10OrLess[0].Quality);
            Assert.Equal(22, backstagePassSellIn10OrLess[1].Quality);
        }

        [Theory]
        [MemberData(nameof(GetBackstagePassSellIn5OrLess))]
        public void UpdateQuality_WithBackstagePass_IncreasesQualityBy3_WhenSellInIs5OrLess(List<Item> backstagePassSellIn5OrLess)
        {
            var logic = new Logic(backstagePassSellIn5OrLess, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(23, backstagePassSellIn5OrLess[0].Quality);
            Assert.Equal(23, backstagePassSellIn5OrLess[1].Quality);
        }

        [Theory]
        [MemberData(nameof(GetBackstagePassAfterConcert))]
        public void UpdateQuality_WithBackstagePass_QualityEquals0AfterConcert(List<Item> backstagePassAfterConcert)
        {
            var logic = new Logic(backstagePassAfterConcert, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(0, backstagePassAfterConcert[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetConjuredItems))]
        public void UpdateQuality_WithConjuredItem_LowersQualityBy2(List<Item> conjuredItem)
        {
            var logic = new Logic(conjuredItem, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(38, conjuredItem[0].Quality);
        }

        [Theory]
        [MemberData(nameof(GetConjuredItemsPassedSellIn))]
        public void UpdateQuality_WithConjuredItemPassedSellIn_LowersQualityBy4(List<Item> conjuredItem)
        {
            var logic = new Logic(conjuredItem, new RulesRepo());
            logic.UpdateQuality();
            Assert.Equal(36, conjuredItem[0].Quality);
        }

    }
}
