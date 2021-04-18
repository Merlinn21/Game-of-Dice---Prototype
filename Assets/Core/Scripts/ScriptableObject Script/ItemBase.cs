using System.Collections;
using UnityEngine;

public enum Kingdom
{
    White,
    Blue,
    Green,
    Red,
    Yellow,
    Black,
    All
}

public enum ItemType
{
    Order,
    WorldEvent,
    Chaos,
    Defensive,
    Beast,
    Construction,
    Weather
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}

public abstract class ItemBase : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Kingdom belongTo;
    [SerializeField] ItemType[] itemTypes;
    [SerializeField] ItemRarity itemRarity;
    [SerializeField] GameObject createdEntity;
    [TextArea(2, 5)]
    [SerializeField] string description;

    public string GetItemName() { return itemName; }
    public Kingdom GetBelongTo() { return belongTo; }
    public ItemType[] GetItemTypes() { return itemTypes; }
    public GameObject GetCreatedEntity() { return createdEntity; }
    public string GetDescription() { return description; }

    public abstract void DoEffect(DiceRoll dices);

    public abstract void InitEffect(DiceRoll dices);
}
