using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.UI;
using TMPro;


public class GameManagerScript : MonoBehaviour
{

    public int coIleDni=288;
    public int wariacjaDni = 5;
    public GameObject panelDarking;
    public float maxDarkness = 30;
    public bool panelFadeIn = false;
    public bool panelFadeOut = false;
    public float fadeSpeed = 0.5f;

    public GameObject monitor;
    public float monitorSlideSpeed;

    public bool slideMonitorIn=false;
    public bool slideMonitorOut=false;

    public Vector3 monitorPosRead = new Vector3(0, 0,0);
    public Vector3 monitorPosHide = new Vector3(50, 0,0);

    public CardManagerScript cardManager;

    public int captainSanity = 50;
    public int captainSanityMax = 100;
    public Slider captainSanitySlider;

    public int supply = 50;
    public int supplyMax = 100;
    public Slider supplySlider;

    public int crewMorale = 50;
    public int crewMoraleMax = 100;
    public Slider crewMoraleSlider;

    public int spaceCraft = 50;
    public int spaceCraftMax = 100;
    public Slider spaceCraftSlider;

    public CardManagerScript _cardManagerScript;


    private float time ;

    private bool czyRozjasniloNaPocz = false;

    public TextMeshProUGUI daysLeftText;
    public int LenghtOfJourney = 1600;

    /*Ekran powoli siê rozjaœnia -(po chwili)-> pojawia siê ekran z pierwsz¹ decyzn
     * 
     * 
     */
    void Awake()
    {
        DontDestroyOnLoad(this);
        monitor.transform.position = monitorPosHide;
        panelDarking.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        _cardManagerScript = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManagerScript>();
        time = Time.deltaTime;
        daysLeftText.text = LenghtOfJourney.ToString();
        
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (panelFadeIn)
        {
            if (panelDarking.GetComponent<Image>().color.a >= maxDarkness)
            {
                panelFadeIn = false;
            }
            else
            {
                panelFadeOut = false;
                panelDarking.GetComponent<Image>().color = new Color(panelDarking.GetComponent<Image>().color.r, panelDarking.GetComponent<Image>().color.g, panelDarking.GetComponent<Image>().color.b, panelDarking.GetComponent<Image>().color.a + fadeSpeed * Time.deltaTime);
            }
           
        }
        if (panelFadeOut)
        {
            if (panelDarking.GetComponent<Image>().color.a <= 0)
            {
                panelFadeOut = false;
            }
            else
            {
                //panelFadeIn = false;
                panelDarking.GetComponent<Image>().color = new Color(panelDarking.GetComponent<Image>().color.r, panelDarking.GetComponent<Image>().color.g, panelDarking.GetComponent<Image>().color.b, panelDarking.GetComponent<Image>().color.a - fadeSpeed * Time.deltaTime);
            }
        }
        if (slideMonitorIn)
        {
            if (Vector3.Distance(monitor.transform.position, monitorPosRead) < 0.1)
            {
                slideMonitorIn = false;
            }
            else
            {
                monitor.transform.position += (monitorPosRead - monitor.transform.position) * Time.deltaTime * monitorSlideSpeed;
            }

        }
        if (slideMonitorOut)
        {
            if (Vector3.Distance(monitor.transform.position, monitorPosHide) < 0.1)
            {
                slideMonitorOut = false;
            }
            else
            {
                monitor.transform.position += (monitorPosHide - monitor.transform.position) * Time.deltaTime * monitorSlideSpeed;
            }
        }
        if (!czyRozjasniloNaPocz) { 

            czyRozjasniloNaPocz = true;
            StartCoroutine(Wstep(5,false));
        }
        
    }


    public void UpdateSiders()
    {
        captainSanitySlider.value = captainSanity / (float)captainSanityMax;
        supplySlider.value = supply / (float)supplyMax;
        crewMoraleSlider.value = crewMorale / (float)crewMoraleMax;
        spaceCraftSlider.value = spaceCraft / (float)spaceCraftMax;
    }

    public void ApplyFeedback(int _captainSanity,int _supply,int _crewMorale, int _spaceCraft)
    {

        captainSanity += _captainSanity;
        supply += _supply;
        crewMorale += _crewMorale;
        spaceCraft += _spaceCraft;
        UpdateSiders();
        Debug.Log("Sanity: " + captainSanity);
        Debug.Log("crew: " + crewMorale);
        Debug.Log("supply: " + supply);
        Debug.Log("space: " + spaceCraft);

        if (captainSanity <= 0)
        {
            Debug.LogWarning("Death 0 sanity");
        }
        if (crewMorale <= 0)
        {
            Debug.LogWarning("Death 0 crew Morale");
        }
        if (supply <= 0)
        {
            Debug.LogWarning("Death 0 suplly");
        }

        if (spaceCraft <= 0)
        {
            Debug.LogWarning("Death 0 spaceCraft");
        }
    }

    public IEnumerator Wstep(float WaitFor, bool czyZmiejszycDni)
    {
        
        yield return new WaitForSeconds(WaitFor);
        panelFadeOut = true;
        yield return new WaitForSeconds(WaitFor);
        _cardManagerScript.drawRandomCard(1,false);
        slideMonitorIn = true;
        if (czyZmiejszycDni)
        {
            daysLeftText.text = (int.Parse(daysLeftText.text) - (coIleDni + Random.Range(-wariacjaDni, wariacjaDni))).ToString();
        }
    }
}