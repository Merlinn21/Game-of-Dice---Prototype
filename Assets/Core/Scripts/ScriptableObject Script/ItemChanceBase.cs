using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Chance/Create new Basic Chance")]
public class ItemChanceBase : ScriptableObject
{
    [SerializeField] int common;
    [SerializeField] int uncommon;
    [SerializeField] int rare;
    [SerializeField] int legendary;

    public int GetCommonChance() { return common; }
    public int GetUncommonChance() { return uncommon; }
    public int GetRareChance() { return rare; }
    public int GetLegendaryChance() { return legendary; }
}
