using System;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    
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
        
    }
}
