using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<ItemBase> allItemList;
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

    private void Start()
    {
        SetChance(0);    
    }

    public void SetChance(int roundIndex)
    {
        if(roundIndex < roundChance.Count)
        {
            currentCommon = roundChance[roundIndex].GetCommonChance();
            currentUncommon = roundChance[roundIndex].GetUncommonChance();
            currentRare = roundChance[roundIndex].GetRareChance();
            currentLegendary = roundChance[roundIndex].GetLegendaryChance();

            ChanceUI();
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
