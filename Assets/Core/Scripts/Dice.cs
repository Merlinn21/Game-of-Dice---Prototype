using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] int modifier = 0;

    public int GetValue() { return value; }
    public void SetValue(int value) { this.value = value; }
    public void AddModifier(int modifier) { this.modifier += modifier; }
    public int GetTotalValue() { return value + modifier; }
    

}
