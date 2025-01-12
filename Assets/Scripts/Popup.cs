using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    public void ClosePopup()
    {
        Destroy(closeBtn);
        Destroy(gameObject);
    }
}
