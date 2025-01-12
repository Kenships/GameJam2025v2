using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image image;
    private Transform parentAfterDrag;
    [SerializeField] Transform screen;

    public void Start()
    {
        if (screen == null)
            screen = transform.parent.parent;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        SetParentAfterDrag(screen);
        transform.SetParent(screen);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void SetParentAfterDrag(Transform parent)
    {
        parentAfterDrag = parent;
    }
    
}
