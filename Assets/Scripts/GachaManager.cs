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
            new() { Letter = "E", rarity = Rarity.Common },
            new() { Letter = "G", rarity = Rarity.Common },
            new() { Letter = "I", rarity = Rarity.Common },
            new() { Letter = "N", rarity = Rarity.Common },
            new() { Letter = "O", rarity = Rarity.Common },
            new() { Letter = "P", rarity = Rarity.Common },
            //new GachaLetter { Letter = "R", rarity = Rarity.Common },
            new() { Letter = "S", rarity = Rarity.Common },
            new() { Letter = "T", rarity = Rarity.Common },
            //new GachaLetter { Letter = "Y", rarity = Rarity.Common },
        };
    }
    public void GetRandomGachaLetter()
    {
        Rarity randomRarity = GetRandomRarity();
        List<GachaLetter> availableLetters = gachaLetters.FindAll(letter => letter.rarity == randomRarity);
        if (availableLetters.Count == 0) randomRarity = Rarity.Common;
        availableLetters = gachaLetters.FindAll(letter => letter.rarity == randomRarity);
        int randomIndex = Random.Range(0, availableLetters.Count);
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
        gachaLetters.Clear();
        gachaLetters.Add(new() {Letter = "R", rarity = Rarity.Common}); 
        gachaLetters.Add(new() {Letter = "Y", rarity = Rarity.Common}); 
    }
}