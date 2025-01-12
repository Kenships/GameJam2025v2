using System;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public ButtonHandler Instance;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayButton(string s)
    {
        Debug.Log(s);
    }
}
