using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using TMPro;



public class CardManagerScript : MonoBehaviour
{
    public allCardsClass Cards;


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

    public GameObject _OptionPrefab;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descrpitionText;
    public Image cardImage;
    public string fileName = "Assets/Data/Cards.json";
    public bool randomizeCard = false;
    void Start()
    {
        
        string jsonString = File.ReadAllText(fileName);
        Cards = JsonConvert.DeserializeObject<allCardsClass>(jsonString);
        Debug.Log(Cards.allCards.Count);

    }

    
    void Update()
    {
        if (randomizeCard)
        {
            randomizeCard = false;
            drawRandomCard(1, false);
        }
    }



    public void drawRandomCard(int wchichFaze, bool unique)
    {
        int index = Random.Range(0, Cards.allCards.Count);
        titleText.text = Cards.allCards[index].CardName;
        descrpitionText.text = Cards.allCards[index].Description;
        for(int i = 0; i < Cards.allCards[index].Options.Count; i++)
        {
            GameObject inst = Instantiate(_OptionPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
            inst.name = "Option" + i.ToString();
        }

    }
}
