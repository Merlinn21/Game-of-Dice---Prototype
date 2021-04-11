using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Vector3[] facesRotation;
    [SerializeField] float[] xyz;

    [SerializeField] int maxRoll = 10; // berapa kali muter sebelum ke value yg udh di random
    [SerializeField] int diceChance = 10; // chance
    [SerializeField] int currentFee = 10;

    [SerializeField] float duration = 5f; //durasi kocok
    [SerializeField] float increment = 0.3f;

    [SerializeField] Text currentChanceText;
    [SerializeField] Text feeText;
    [SerializeField] Text currentPointText;

    [SerializeField] RotateMode rotateMode;
    

    bool isRotating = false;
    bool isWinningSon = true;

    int currentRoll = 0;
    int currentDice = 0;
    int currentPoint = 0;

    private void Start()
    {
        UpdatePointUI();
    }

    public void StartRoll()
    {
        if(currentDice != diceChance && isWinningSon)
        {
            //kalo masih punya chance
            Vector3 targetRoll = RandomRoll();

            isRotating = true;

            currentDice++;

            currentChanceText.text = currentDice.ToString();

            CubeRotate(duration, increment, targetRoll);
        }
        
    }

    public void StopRoll()
    {
        isRotating = false;
    }

    Vector3 RandomRoll()
    {
        //Random Dice
        Vector3 randomFaceRotation = new Vector3();

        float random = Random.Range(0, 1f);

        if(random < 0.167f)
        {
            randomFaceRotation = facesRotation[0];

            currentPoint += 1;
        }
        else if(random < 0.333f)
        {
            randomFaceRotation = facesRotation[1];

            currentPoint += 2;
        }
        else if(random < 0.5f)
        {
            randomFaceRotation = facesRotation[2];

            currentPoint += 3;
        }
        else if(random < 0.667f)
        {
            randomFaceRotation = facesRotation[3];

            currentPoint += 4;
        }
        else if(random < 0.834f)
        {
            randomFaceRotation = facesRotation[4];

            currentPoint += 5;
        }
        else if(random < 1.1f)
        {
            randomFaceRotation = facesRotation[5];

            currentPoint += 6;
        }

        return randomFaceRotation;
    }

    void CubeRotate(float rotateDuration, float increment, Vector3 faceTarget)
    {
        if (!isRotating)
        {
            //Kalo diberhentiin
            currentRoll = 0;

            transform.DOKill();
            transform.DORotate(new Vector3(0, 0, 0), 0);

            return;
        }

        //Buat atur rotasi random kubus
        Vector3 randomFaceRotation = new Vector3(Random.Range(0, transform.rotation.x - xyz[0]), 
                                                 Random.Range(0, transform.rotation.y - xyz[1]), 
                                                 Random.Range(0, transform.rotation.z - xyz[2]));

        //kocok maxRoll kali baru berhenti 
        if (currentRoll != maxRoll)
        {
            //kalo masih belum maxRoll
            transform.DORotate(randomFaceRotation, rotateDuration, rotateMode)
                .OnComplete(() =>
                {
                    currentRoll++;

                    CubeRotate(rotateDuration + increment, increment + increment, faceTarget);
                });
        }
        else
        {
            //kalo udh maxRoll x
            transform.DORotate(faceTarget, rotateDuration);

            currentRoll = 0;

            UpdatePointUI();

            CheckGameOver();
        }

    }

    void CheckGameOver()
    {
        if (currentDice != diceChance) return;

        if(currentPoint >= currentFee)
        {
            currentPoint = currentPoint - currentFee;

            currentFee = Mathf.RoundToInt(currentFee + (currentFee * 0.25f));;

            currentDice = 0;

            UpdatePointUI();
        }
        else
        {
            //GameOver
            isWinningSon = false;
        }
        
    }

    void UpdatePointUI()
    {
        currentChanceText.text = currentDice.ToString();
        currentPointText.text = currentPoint.ToString();
        feeText.text = currentFee.ToString();
    }
}
