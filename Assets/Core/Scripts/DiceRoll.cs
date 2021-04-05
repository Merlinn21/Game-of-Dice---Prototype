using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiceRoll : MonoBehaviour
{
    int roll = 0;
    public float xAngle, yAngle, zAngle = 0f;
    public float time = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DORotate(new Vector3(180, 0, 90), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
