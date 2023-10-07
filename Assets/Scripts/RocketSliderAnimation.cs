using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketSliderAnimation : MonoBehaviour
{
    public Sprite[] rocket;
    public int indexSpriteRocket = 0;
    double time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
      
        if (time >= 0.1f)
        {
            time = Time.deltaTime;
            indexSpriteRocket++;
            indexSpriteRocket = indexSpriteRocket % 3;
            GetComponent<Image>().sprite = rocket[indexSpriteRocket];
        }
    }

    
}
