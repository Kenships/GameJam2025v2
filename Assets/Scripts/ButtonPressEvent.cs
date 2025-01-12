using UnityEngine;

[CreateAssetMenu(fileName = "ButtonPressEvent", menuName = "Event/ButtonPressEvent")]
public class ButtonPressEvent : GenericEventChannelSO<string>
{
    
}

public class Word
{
    public string word;

    public Word(string word)
    {
        this.word = word;
    }
}
