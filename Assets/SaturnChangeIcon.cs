using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaturnChangeIcon : MonoBehaviour
{
    public Sprite sat0;
    public Sprite sat1;
    public Sprite sat2;

    //public sliderPercent sliderDaysLeftPercentScript;
    public Slider sliderDaysLeft;

    private void Awake()
    {
       
    }
    void Update()
    {
        if (sliderDaysLeft.value >= 0 && sliderDaysLeft.value < 0.33f)
        {
            changeSaturnSprite(0);
        }
        else if (sliderDaysLeft.value >= 0.33f && sliderDaysLeft.value < 0.66f)
        {
            changeSaturnSprite(1);


        }
        else if (sliderDaysLeft.value >= 0.66f)
        {
            changeSaturnSprite(2);
        }
    }

    public void changeSaturnSprite(int index)
    {
        //Debug.Log(index);
        switch (index)
        {
            
            case 0:
                GetComponent<SpriteRenderer>().sprite = sat0;
                break;

            case 1:
                GetComponent<SpriteRenderer>().sprite = sat1;

                break;


            case 2:
                GetComponent<SpriteRenderer>().sprite = sat2;

                break;

            default:
                GetComponent<SpriteRenderer>().sprite = sat0;

                break;
        }
    }
}
