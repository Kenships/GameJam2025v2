using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] Sprite endScreen;
    [SerializeField] private Image image;
    private void Start()
    {
        Invoke(nameof(SetSprite), 2f);
    }

    private void SetSprite()
    {
        image.sprite = endScreen;
    }
}
