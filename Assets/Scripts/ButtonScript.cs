using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] Letter letterPrefab;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] GridLayoutGroup gridLayoutGroup;
    [SerializeField] private LetterSettingsSO cellSize;
    [SerializeField] private LetterSettingsSO letterSize;
    [SerializeField] private string buttonText;
    [SerializeField] private ButtonPressEvent pressEvent;
    public void SetString(string inputString)
    {
        buttonText = inputString;
        foreach (var c in inputString)
        {
            Letter letter = Instantiate(letterPrefab, transform);
            letter.SetLetter((LetterType)(c - 'A'));
        }

        rectTransform.sizeDelta = new Vector2(cellSize.cellSize * 10, cellSize.cellSize);
        gridLayoutGroup.cellSize = new Vector2(letterSize.cellSize, letterSize.cellSize);
    }

    public void InvokeButtonEvent()
    {
        pressEvent.RaiseEvent(buttonText);
    }
}
