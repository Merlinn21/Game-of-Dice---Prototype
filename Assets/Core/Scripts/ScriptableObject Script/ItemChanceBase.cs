using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Chance/Create new Basic Chance")]
public class ItemChanceBase : ScriptableObject
{
    [SerializeField] float common;
    [SerializeField] float uncommon;
    [SerializeField] float rare;
    [SerializeField] float legendary;

    public float GetCommonChance() { return common; }
    public float GetUncommonChance() { return uncommon; }
    public float GetRareChance() { return rare; }
    public float GetLegendaryChance() { return legendary; }
}
