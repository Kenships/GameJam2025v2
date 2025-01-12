using UnityEngine;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{
    private Button button;
    [SerializeField] private Sprite checkedSprite;
    [SerializeField] private Image image;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GachaManager.Instance.AddRYLetters();
        image.sprite = checkedSprite;
    }
}
