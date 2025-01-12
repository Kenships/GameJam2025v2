using System;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager: MonoBehaviour
{
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

    public List<GachaLetter> gachaLetters;
    
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
            new GachaLetter { Letter = "A", rarity = Rarity.Legendary },
            new GachaLetter { Letter = "B", rarity = Rarity.Rare },
            new GachaLetter { Letter = "C", rarity = Rarity.Common },
        };
    }
    private GachaLetter GetRandomGachaLetter()
    {
        Rarity randomRarity = GetRandomRarity();
        
        List<GachaLetter> availableLetters = gachaLetters.FindAll(letter => letter.rarity == randomRarity);
        
        int randomIndex = UnityEngine.Random.Range(0, availableLetters.Count);
        return availableLetters[randomIndex];
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
}