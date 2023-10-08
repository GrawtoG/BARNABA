using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnChangeIcon : MonoBehaviour
{
    public Sprite sat0;
    public Sprite sat1;
    public Sprite sat2;
    
    void Update()
    {
        
    }

    public void changeSaturnSprite(int index)
    {
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
