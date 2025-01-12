using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour, IDragHandler
{
  public Canvas draggable_window;
  private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rectTransform = GetComponent<RectTransform>(); 
    }
    void IDragHandler.OnDrag(PointerEventData eventData) 
    {
      rectTransform.anchoredPosition += eventData.delta;
    }
}
