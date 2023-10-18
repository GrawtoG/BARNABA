using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToSkipFeedback : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManagerScript _gameManagerScript;
    public CardManagerScript _cardManagerScript;
    void Awake()
    {
        _gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        _cardManagerScript = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        _gameManagerScript.fadeSpeed = 1;
        _gameManagerScript.panelFadeIn = true;
        _gameManagerScript.slideMonitorOut = true;
        

        StartCoroutine(_gameManagerScript.Wstep(3, true));
        
    }
}
