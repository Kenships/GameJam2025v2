using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GachaManager: MonoBehaviour
{
    public static GachaManager Instance{get; private set;}

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public enum Rarity
    {
        Legendary,
        Common,
        Rare,
    }
    [System.Serializable]
    public class GachaLetter
    {
        public string Letter;
        public Rarity rarity;
        
        
    }
    [SerializeField] private ButtonPressEvent _buttonPressEvent;
    public List<GachaLetter> gachaLetters;
    private Dictionary<GachaLetter, int> gachaLettersDictionary = new Dictionary<GachaLetter, int>();
    private Dictionary<Rarity, float> rarityWeights = new Dictionary<Rarity, float>
    {
        { Rarity.Common, 60f },    
        { Rarity.Rare, 30f },      
        { Rarity.Legendary, 10f}
    };

    // Start is called before the first frame update
    void Start()
    { 
        InitializeGachaLetters();
    }
    private void InitializeGachaLetters()
    {   
        // add letters here!
        gachaLetters = new List<GachaLetter>
        {
            new() { Letter = "A", rarity = Rarity.Common },
            new() { Letter = "B", rarity = Rarity.Common },
            new() { Letter = "C", rarity = Rarity.Common },
            new() { Letter = "D", rarity = Rarity.Common },
            new() { Letter = "E", rarity = Rarity.Common },
            new() { Letter = "F", rarity = Rarity.Common },
            new() { Letter = "G", rarity = Rarity.Rare },
            new() { Letter = "H", rarity = Rarity.Common },
            new() { Letter = "I", rarity = Rarity.Rare },
            new() { Letter = "J", rarity = Rarity.Common },
            new() { Letter = "K", rarity = Rarity.Common },
            new() { Letter = "L", rarity = Rarity.Common },
            new() { Letter = "M", rarity = Rarity.Common },
            new() { Letter = "N", rarity = Rarity.Rare },
            new() { Letter = "O", rarity = Rarity.Common },
            new() { Letter = "P", rarity = Rarity.Common },
            new() { Letter = "Q", rarity = Rarity.Common },
            //new GachaLetter { Letter = "R", rarity = Rarity.Common },
            new() { Letter = "S", rarity = Rarity.Rare },
            new() { Letter = "T", rarity = Rarity.Rare },
            new() { Letter = "U", rarity = Rarity.Common },
            new() { Letter = "V", rarity = Rarity.Common },
            new() { Letter = "W", rarity = Rarity.Common },
            new() { Letter = "X", rarity = Rarity.Common },
            //new GachaLetter { Letter = "Y", rarity = Rarity.Common },
            new GachaLetter { Letter = "Z", rarity = Rarity.Common },
        };
    }
    public void GetRandomGachaLetter()
    {
        Rarity randomRarity = GetRandomRarity();
        List<GachaLetter> availableLetters = gachaLetters.FindAll(letter => letter.rarity == randomRarity);
        int randomIndex = Random.Range(0, availableLetters.Count - 1);
        if (availableLetters.Count == 0)
        {
            return;
        }
        GachaLetter gachaLetter = availableLetters[randomIndex];
        _buttonPressEvent.RaiseEvent(gachaLetter.Letter);
    }

    private Rarity GetRandomRarity()
    {
        float totalWeight = 100f;

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        foreach (KeyValuePair<Rarity, float> rarityWeight in rarityWeights)
        {
            cumulativeWeight += rarityWeight.Value;
            if (randomValue < cumulativeWeight)
            {
                return rarityWeight.Key;
            }
        }
        
        Debug.Log("debug: didn't find a random rarity, returning common.");
        return Rarity.Common;
    }

    public void AddRYLetters()
    {
        gachaLetters.Add(new() {Letter = "R", rarity = Rarity.Legendary}); 
        gachaLetters.Add(new() {Letter = "Y", rarity = Rarity.Legendary}); 
    }
}