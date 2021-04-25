using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    [SerializeField] List<ItemBase> commonItems;
    [SerializeField] List<ItemBase> uncommonItems;
    [SerializeField] List<ItemBase> rareItems;
    [SerializeField] List<ItemBase> legendaryItems;

    public List<ItemBase> GetCommon() { return commonItems; }
    public List<ItemBase> GetUncommon() { return uncommonItems; }
    public List<ItemBase> GetRare() { return rareItems; }
    public List<ItemBase> GetLegendary() { return legendaryItems; }


}
