using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sliderPercent : MonoBehaviour
{
    public TextMeshProUGUI sliderText;
    public int fullDays = 2800;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sliderText != null)
        {
            GetComponent<Slider>().value = ((fullDays - int.Parse(sliderText.text)) / (float)(fullDays));
        }
        else
        {
            GetComponent<Slider>().value = 1;
        }
        
    }
}
