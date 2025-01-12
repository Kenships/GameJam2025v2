using UnityEngine;

public class WorldLibraryHandler : MonoBehaviour
{
    [SerializeField] private WordLibrarySO wordLibrary;
    [SerializeField] private WordLibrarySO wordLibraryDefault;

    public void Awake()
    {
        wordLibrary.library.Clear();
        wordLibraryDefault.library.ForEach(w => wordLibrary.library.Add(w));
    }

    public void RemoveWord(string word)
    {
        Debug.Log("Removed :" + word);
        wordLibrary.library.Remove(word);
    }
}
