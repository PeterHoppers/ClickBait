using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TextAnimation : MonoBehaviour
{
    public string first;
    public string second;

    Text firstWord;
    Text secondWord;

    public float increaseSpeed;
    private float increasedOriginal;
    private float sizeOne = 15;
    private float sizeTwo = 15;
    private int endCnt = 0;
    private bool isDone;

    // Use this for initialization
    void Start()
    {
        firstWord = GameObject.FindGameObjectWithTag("FirstWord").GetComponent<Text>();
        secondWord = GameObject.FindGameObjectWithTag("SecondWord").GetComponent<Text>();
        firstWord.text = first;
        secondWord.text = second;
        firstWord.gameObject.SetActive(false);
        secondWord.gameObject.SetActive(false);
        increasedOriginal = increaseSpeed;
    }


    void Update()
    {
        if (!isDone)
        {
            DoAnimation();
        }

    }

    public void DoAnimation()
    {
        if (sizeOne < 300)
        {
            firstWord.gameObject.SetActive(true);
            increaseSpeed = increaseSpeed + .15f;
            sizeOne =  Mathf.Pow((float)Math.E, increaseSpeed);
            firstWord.fontSize = (int)sizeOne;
            return;
        }
        else
        {
            if (sizeTwo == 15)
            {
                increaseSpeed = increasedOriginal;
                secondWord.gameObject.SetActive(true);
            }

            if (sizeTwo < 300)
            {
                increaseSpeed = increaseSpeed + .15f;
                sizeTwo = Mathf.Pow((float)Math.E, increaseSpeed);
                secondWord.fontSize = (int)sizeTwo;
                return;
            }
            else
            {
                if (endCnt < 50)
                {
                    endCnt++;
                }
                else
                {
                    firstWord.gameObject.SetActive(false);
                    secondWord.gameObject.SetActive(false);
                    isDone = true;
                }
                
            }
        }
    }
}
