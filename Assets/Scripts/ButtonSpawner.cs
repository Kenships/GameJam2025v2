using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] ButtonScript buttonScript;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private LetterSettingsSO cellSize;
    [SerializeField] private LetterSettingsSO letterSize;
    [SerializeField] private ExpandableLetterBox expandableLetterBox;
    [SerializeField] private WordLibrarySO wordLibrary;

    public void Start()
    {
        Vector2 size = new Vector2(cellSize.cellSize * 10, cellSize.cellSize);
        rectTransform.sizeDelta = size;
        gridLayoutGroup.cellSize = size;
    }

    public void SpawnButton()
    {
        string word = expandableLetterBox.GetWord();
        if (wordLibrary.library.Contains(word))
        {
            ButtonScript button = Instantiate(buttonScript, rectTransform);
            button.SetString(word);
        }
    }
}
