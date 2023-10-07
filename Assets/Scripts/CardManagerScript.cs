using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using TMPro;



public class CardManagerScript : MonoBehaviour
{



    public class Option
    {
        public string OptionName { get; set; }
        public int CrewMorale { get; set; }
        public int ShipCondition { get; set; }
        public int CaptainSanity { get; set; }
        public int Supplies { get; set; }

        public string feedback { get; set; }
    }
    public class Card
    {
        bool wasPlayed;
        public string CardName { get; set; }
        public string Description { get; set; }
        public int Probability { get; set; }
        public List<Option> Options { get; set; }


    }
    public class allCardsClass
    {
        public List<Card> allCards;
    }

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descrpitionText;
    public Image cardImage;
    public string fileName = "Assets/Data/Cards.json";

    void Start()
    {
        allCardsClass Cards;
        string jsonString = File.ReadAllText(fileName);
        Cards = JsonConvert.DeserializeObject<allCardsClass>(jsonString);
        Debug.Log(Cards.allCards.Count);

    }

    
    void Update()
    {
        
    }



    public void drawRandomCard(int ktoraFaza)
    {



    }
}
