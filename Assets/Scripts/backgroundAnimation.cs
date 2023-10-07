using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundAnimation : MonoBehaviour
{
    
    public bool rotZ = true;
    public float rotZSpeed = 0.1f;
    void Start()
    {
        rotZSpeed /= 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotZ)
        {
            GetComponent<Transform>().Rotate(new Vector3 (0, 0, 1), rotZSpeed);
        }



    }
}
