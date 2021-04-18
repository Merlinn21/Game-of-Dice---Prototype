using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create new Basic Item")]
public class BasicItem : ItemBase
{
    [SerializeField] Kingdom[] targetPlusEffect;
    [SerializeField] Kingdom[] targetMinusEffects;
    [SerializeField] int plusEffect;
    [SerializeField] int minusEffect;

    public Kingdom[] GetTargetPlusEffect() { return targetPlusEffect; }
    public Kingdom[] GetTargetMinusEffects() { return targetMinusEffects; }

    public override void DoEffect(DiceRoll diceRoll)
    {
        // Ga ada effect cuma ngubah modifier;
    }

    public override void InitEffect(DiceRoll diceRoll)
    {
        if (targetPlusEffect[0] != Kingdom.All)
        {
            foreach (Kingdom target in targetPlusEffect)
            {
                int index = 0;

                switch (target)
                {
                    case Kingdom.White:
                        index = 0;
                        break;
                    case Kingdom.Blue:
                        index = 1;
                        break;
                    case Kingdom.Green:
                        index = 2;
                        break;
                    case Kingdom.Red:
                        index = 3;
                        break;
                    case Kingdom.Yellow:
                        index = 4;
                        break;
                    case Kingdom.Black:
                        index = 5;
                        break;
                }

                diceRoll.dices[index].AddModifier(plusEffect);
            }
        }
        else
        {
            for(int i = 0; i < diceRoll.dices.Length; i++)
            {
                diceRoll.dices[i].AddModifier(plusEffect);
            }
        }
        

        if(targetMinusEffects[0] != Kingdom.All)
        {
            foreach (Kingdom target in targetMinusEffects)
            {
                int index = 0;

                switch (target)
                {
                    case Kingdom.White:
                        index = 0;
                        break;
                    case Kingdom.Blue:
                        index = 1;
                        break;
                    case Kingdom.Green:
                        index = 2;
                        break;
                    case Kingdom.Red:
                        index = 3;
                        break;
                    case Kingdom.Yellow:
                        index = 4;
                        break;
                    case Kingdom.Black:
                        index = 5;
                        break;
                }

                diceRoll.dices[index].AddModifier(-minusEffect);
            }
        }
        else
        {
            for (int i = 0; i < diceRoll.dices.Length; i++)
            {
                diceRoll.dices[i].AddModifier(-minusEffect);
            }
        }
        
    }

}
