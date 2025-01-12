using UnityEngine;

public class Pointer : MonoBehaviour
{

    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite cursorDown;
    void Awake()
    {
        Cursor.SetCursor(cursor.texture, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorDown.texture, Vector2.zero, CursorMode.Auto);
        }
    }
    
}
