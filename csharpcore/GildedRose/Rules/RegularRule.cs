using GildedRoseKata;

namespace GildedRose.Rules
{
    public class RegularRule : IRule
    {
        public Item ApplyRule(Item item)
        {
            item.Quality--;
            if (item.SellIn <= 0)
                item.Quality--;
            return item;
        }
    }
}
