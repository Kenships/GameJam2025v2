using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Transform popupHolder;
    [SerializeField] private GameObject helpPage;
    [SerializeField] private GameObject optionsPage;
    [SerializeField] private GameObject GachaButton;
    private GameObject _helpPage;
    private GameObject _optionsPage;
    private GameObject _gachaPage;
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
                    GenerateGacha();
                    break;
            case "PLAY":
                case "START":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    private void GenerateGacha()
    {
        if (!_gachaPage)
        {
            _gachaPage = Instantiate(GachaButton, popupHolder);
            //_gachaPage.transform.position = new Vector3(0, 470, 0);
        }
    }
    private void GenerateOptionsPage()
    {
        if (!_optionsPage)
        {
            _optionsPage = Instantiate(optionsPage, popupHolder);
            _optionsPage.transform.position += 5 * new Vector3(popupHolder.childCount, popupHolder.childCount, 0);
        }
    }

    private void GenerateHelpPage()
    {
        if (!_helpPage)
        {
            _helpPage = Instantiate(helpPage, popupHolder);
            _helpPage.transform.position += 5 * new Vector3(popupHolder.childCount, popupHolder.childCount, 0);
        }
    }
}
