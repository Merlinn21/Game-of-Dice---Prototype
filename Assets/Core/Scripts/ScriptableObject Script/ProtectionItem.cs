using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create new Protection Item")]
public class ProtectionItem : ItemBase
{
    [SerializeField] Kingdom[] targetPlusEffect;
    [SerializeField] Kingdom[] targetMinusEffects;
    [SerializeField] int plusEffect;
    [SerializeField] int minusEffect;

    public override void DoEffect(DiceRoll diceRoll)
    {

    }

    public override void InitEffect(DiceRoll diceRoll)
    {
       
    }

}
