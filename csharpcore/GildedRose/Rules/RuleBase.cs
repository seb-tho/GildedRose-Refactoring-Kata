using GildedRoseKata;

namespace GildedRose
{
    public abstract class RuleBase
    {
        public virtual Item ApplyRule(Item item)
        {
            item.Quality--;
            if (item.SellIn <= 0)
                item.Quality--;
            return item;
        }
    }
}
