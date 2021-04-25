using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemPool itemPool;
    [SerializeField] List<ItemChanceBase> roundChance;
    [SerializeField] List<ItemBase> ownedItem;
    [SerializeField] ItemBase testingItem;

    [SerializeField] Text commonText;
    [SerializeField] Text uncommonText;
    [SerializeField] Text rareText;
    [SerializeField] Text legendText;

    float currentCommon = 0;
    float currentUncommon = 0;
    float currentRare = 0;
    float currentLegendary = 0;

    List<ItemBase> commonPool;
    List<ItemBase> uncommonPool;
    List<ItemBase> rarePool;
    List<ItemBase> legendaryPool;

    int roundIndex = 0;

    private void Start()
    {
        initItemList();

        SetChance(0);
    }

    private void initItemList()
    {
        commonPool = itemPool.GetCommon();
        uncommonPool = itemPool.GetUncommon();
        rarePool = itemPool.GetRare();
        legendaryPool = itemPool.GetLegendary();
    }

    public void SetChance(int index)
    {
        roundIndex = index;

        if(roundIndex < roundChance.Count)
        {
            currentCommon = roundChance[roundIndex].GetCommonChance();
            currentUncommon = roundChance[roundIndex].GetUncommonChance();
            currentRare = roundChance[roundIndex].GetRareChance();
            currentLegendary = roundChance[roundIndex].GetLegendaryChance();

            ChanceUI();
        }


        for (int i = 0; i < 100; i++)
        {
            Debug.Log(index + ": "+RandomItem.GetRandomItem(roundChance[roundIndex]));
        }
    }

    public void ChanceUI()
    {
        commonText.text = currentCommon.ToString();
        uncommonText.text = currentUncommon.ToString();
        rareText.text = currentRare.ToString();
        legendText.text = currentLegendary.ToString();
    }

    public void CheckItem(DiceRoll diceRoll, Kingdom currentKingdom)
    {
        if (ownedItem.Count == 0) return;

        if(testingItem == null)
        {
            foreach(ItemBase item in ownedItem)
            {
                if (item.GetBelongTo().Equals(currentKingdom))
                {
                    item.DoEffect(diceRoll);
                }
            }
        }
        else
        {
            ownedItem[0].DoEffect(diceRoll);
        }

    }

    public void AddItem(DiceRoll diceRoll)
    {
        if (testingItem != null)
        {
            //Jalanin kode biasa
            ownedItem.Add(testingItem);
            ownedItem[0].InitEffect(diceRoll);
        }
        else
        {
            ownedItem.Add(testingItem);
            ownedItem[0].InitEffect(diceRoll);
        }
    }
}
