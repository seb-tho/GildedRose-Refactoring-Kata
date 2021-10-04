using GildedRoseKata;

namespace GildedRose.Rules
{
    public class ConjuredRule : IRule
    {
        public Item ApplyRule(Item item)
        {
            item.Quality -= 2;
            if (item.SellIn <= 0)
                item.Quality -= 2;
            return item;
        }
    }
}
