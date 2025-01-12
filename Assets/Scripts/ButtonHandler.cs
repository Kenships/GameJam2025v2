using System;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Transform popupHolder;
    [SerializeField] private GameObject helpPage;
    public void PlayButton(string s)
    {
        switch (s)
        {
            case "CLOSE":
                case "EXIT":
                case "QUIT":
                case "KILL":
                Application.Quit();
                break;
            
            case "HINT":
                case "HELP":
                case "CLUE":
                    GenerateHelpPage();
                    break;
            
            case "SETTINGS":
                case "OPTIONS":
                    GenerateOptionsPage();
                    break;
            
            case "GACHA":
                case "SHOP":
                    
                    break;
        }
    }

    private void GenerateOptionsPage()
    {
        
    }

    private void GenerateHelpPage()
    {
        GameObject popup = Instantiate(helpPage, popupHolder);
        popup.transform.position += 5 * new Vector3(popupHolder.childCount, popupHolder.childCount, 0);
    }
}
