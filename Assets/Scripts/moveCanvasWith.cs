using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCanvasWith : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform moveWith;

     public Camera camera;
    Vector2 posScreen;
    Vector2 pos;
    private RectTransform rt;
    void Awake()
    {
        pos = moveWith.position;
        rt = GetComponent<RectTransform>();
        posScreen = camera.WorldToViewportPoint(moveWith.TransformPoint(pos));
        rt.anchoredPosition = posScreen + new Vector2(0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<RectTransform>().localPosition = new Vector3(moveWith.position.x,GetComponent<RectTransform>().position.y);
        
        posScreen = camera.WorldToViewportPoint(moveWith.TransformPoint(pos));
        rt.anchorMax = pos;
        rt.anchorMin = pos;


    }
}
