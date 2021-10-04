﻿using GildedRose;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Logic
    {
        private readonly IList<Item> Items;
        private readonly RulesRepo RulesRepo;

        public Logic(IList<Item> items, RulesRepo rulesRepo)
        {
            Items = items;
            RulesRepo = rulesRepo;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if(RulesRepo.Rules.TryGetValue(item.Name, out IRule rule))
                {
                    rule.ApplyRule(item);
                }
                else if (item.Name.StartsWith(RulesRepo.CONJURED))
                {
                    RulesRepo.Rules.GetValueOrDefault(RulesRepo.CONJURED).ApplyRule(item);
                }
                else
                {
                    RulesRepo.Rules.GetValueOrDefault(RulesRepo.REGULAR).ApplyRule(item);
                }
            }
        }
    }
}
