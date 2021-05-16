using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] DiceRoll diceRoll;
    [SerializeField] ItemPool itemPool;
    [SerializeField] List<ItemChanceBase> roundChance;
    [SerializeField] List<ItemBase> ownedItem;
    [SerializeField] ItemBase testingItem;

    [SerializeField] Text commonText;
    [SerializeField] Text uncommonText;
    [SerializeField] Text rareText;
    [SerializeField] Text legendText;

    [SerializeField] GameObject chooseItemPanel;
    [SerializeField] GameObject[] itemsPanel;

    float currentCommon = 0;
    float currentUncommon = 0;
    float currentRare = 0;
    float currentLegendary = 0;

    List<ItemBase> commonPool;
    List<ItemBase> uncommonPool;
    List<ItemBase> rarePool;
    List<ItemBase> legendaryPool;
    [SerializeField] List<ItemBase> randomChoices = new List<ItemBase>();

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

        if (roundIndex < roundChance.Count)
        {
            currentCommon = roundChance[roundIndex].GetCommonChance();
            currentUncommon = roundChance[roundIndex].GetUncommonChance();
            currentRare = roundChance[roundIndex].GetRareChance();
            currentLegendary = roundChance[roundIndex].GetLegendaryChance();

            ChanceUI();
        }

        /*for (int i = 0; i < 100; i++)
        {
            Debug.Log(index + ": " + RandomItem.GetRandomItem(roundChance[roundIndex]));
        }*/
    }

    public void ChanceUI()
    {
        commonText.text = currentCommon.ToString();
        uncommonText.text = currentUncommon.ToString();
        rareText.text = currentRare.ToString();
        legendText.text = currentLegendary.ToString();
    }

    public void CheckItem(Kingdom currentKingdom)
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

    public void AddItem(int index)
    {
        ownedItem.Add(randomChoices[index]);
        randomChoices[index].InitEffect(diceRoll);
    }

    public void OpenPanel()
    {
        chooseItemPanel.SetActive(true);

        RandomizeItemsChoice();
    }

    public void ClosePanel()
    {
        chooseItemPanel.SetActive(false);
    }

    public void ClearChoices()
    {
        randomChoices.Clear();
    }

    void RandomizeItemsChoice()
    {
        randomChoices = new List<ItemBase>();

        for(int i = 0; i < itemsPanel.Length; i++)
        {
            int itemRarity = 0;

            if (roundIndex < roundChance.Count)
                itemRarity = RandomItem.GetRandomItem(roundChance[roundIndex]);
            else
                itemRarity = RandomItem.GetRandomItem(roundChance[roundChance.Count - 1]);

            ItemBase item;

            List<ItemBase> itemRarityPool = new List<ItemBase>();

            //Sementara bener bener random
            switch (itemRarity)
            {
                case RandomItem.COMMON_RARITY:
                    itemRarityPool = commonPool;
                    break;
                case RandomItem.UNCOMMON_RARITY:
                    itemRarityPool = uncommonPool;
                    break;
                case RandomItem.RARE_RARITY:
                    itemRarityPool = rarePool;
                    break;
                case RandomItem.LEGENDARY_RARITY:
                    itemRarityPool = legendaryPool;
                    break;
            }

            int randomItem = Random.Range(0, itemRarityPool.Count);

            //TODO: ambil item description, sprite, dll.
            itemsPanel[i].gameObject.GetComponentInChildren<Text>().text = itemRarityPool[randomItem].GetItemName();

            randomChoices.Add(itemRarityPool[randomItem]);
        }
    }
}
