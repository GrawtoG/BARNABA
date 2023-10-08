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

    [System.Serializable]
    public struct OptionIcon{
        public string extension;
        public Sprite iconImage;
    }

    public GameObject _OptionPrefab;


    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descrpitionText;
    public Image cardImage;
    public string jsonWithCardsPath = "Assets/Data/Cards.json";
    public string cardsImagesPath = "Assets/Resources/CardsGraphics/";
    public bool randomizeCard = false;

    public OptionIcon[] iconsOptions;
    void Start()
    {
        
        string jsonString = File.ReadAllText(jsonWithCardsPath);
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

        Texture2D tex = LoadTexture(cardsImagesPath + Cards.allCards[index].CardName.Replace(" ", "")+".png");
 
        
        cardImage.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        for(int i = 0; i < Cards.allCards[index].Options.Count; i++)
        {
            GameObject inst = Instantiate(_OptionPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
            inst.name = "Option" + i.ToString();
            inst.GetComponent<SpriteRenderer>().sprite = iconsOptions[Random.Range(0, iconsOptions.Length)].iconImage;
        }

    }


    public Texture2D LoadTexture(string FilePath)
    {

       
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           
            if (Tex2D.LoadImage(FileData))         
                return Tex2D;
        }
        else
        {
            Debug.LogWarning("NIE MA TAKIEGO PLIKU");
        }
        return null;                     
    }
}
