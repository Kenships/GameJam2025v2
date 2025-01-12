using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ButtonVisual : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image myImage;
    [SerializeField] private Sprite pressed;
    [SerializeField] private Sprite unpressed;


    public void OnPointerDown(PointerEventData eventData)
    {
        //myImage.sprite = pressed;
        transform.position -= new Vector3(5, 5, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //myImage.sprite = unpressed;
        transform.position += new Vector3(5, 5, 0);
    }
}
