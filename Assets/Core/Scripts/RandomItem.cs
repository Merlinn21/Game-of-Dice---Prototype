using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public static class RandomItem
{
    private static Random random = new Random();

    public static int COMMON_RARITY = 0;
    public static int UNCOMMON_RARITY = 1;
    public static int RARE_RARITY = 2;
    public static int LEGENDARY_RARITY = 3;

    public static int GetRandomItem(ItemChanceBase itemChanceBase)
    {
        int selectedRarity = 0;
        int totalWeight = 0;

        List<int> chanceList = new List<int>();

        chanceList.Add(itemChanceBase.GetCommonChance());
        chanceList.Add(itemChanceBase.GetUncommonChance());
        chanceList.Add(itemChanceBase.GetRareChance());
        chanceList.Add(itemChanceBase.GetLegendaryChance());

        totalWeight += itemChanceBase.GetCommonChance();
        totalWeight += itemChanceBase.GetUncommonChance();
        totalWeight += itemChanceBase.GetRareChance();
        totalWeight += itemChanceBase.GetLegendaryChance();

        int randomNumber = random.Next(0, totalWeight);

        foreach(int rarity in chanceList)
        {
            if(randomNumber < rarity)
            {
                if (rarity.Equals(itemChanceBase.GetCommonChance())) selectedRarity = COMMON_RARITY;
                else if (rarity.Equals(itemChanceBase.GetUncommonChance())) selectedRarity = UNCOMMON_RARITY;
                else if (rarity.Equals(itemChanceBase.GetRareChance())) selectedRarity = RARE_RARITY;
                else if (rarity.Equals(itemChanceBase.GetLegendaryChance())) selectedRarity = LEGENDARY_RARITY;

                break;
            }

            randomNumber = randomNumber - rarity;
        }

        return selectedRarity;
    }
}
