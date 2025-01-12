using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenController : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Vector3 mouseDelta = eventData.delta;
            transform.position += mouseDelta;
        }
    }
}
