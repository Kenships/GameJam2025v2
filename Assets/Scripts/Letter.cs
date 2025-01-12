using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Letter : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private LetterSettingsSO letterSettings;
    [SerializeField] private Image image;
    [SerializeField] SpriteLibrarySO letterSprites;
    [SerializeField] private SpriteLibrarySO letterSpritesPlaceholder;
    [SerializeField] private LetterType letter;
    [SerializeField] private bool showLetter;

    public void Start()
    {
        rectTransform.sizeDelta = new Vector2(letterSettings.cellSize, letterSettings.cellSize);
        SetLetter(letter);
        if (showLetter)
        {
            ShowLetter();
        }
        else
        {
            PlaceHoldLetter();
        }
    }

    public void ShowLetter()
    {
        image.sprite = letterSprites.spriteList[(int) letter];
    }

    public void PlaceHoldLetter()
    {
        image.sprite = letterSpritesPlaceholder.spriteList[(int) letter];
    }
    public void SetLetter(LetterType letterType)
    {
        letter = letterType;
        image.sprite = letterSprites.spriteList[(int) letterType];
    }

    public string GetLetter()
    {
        return letter.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowLetter();
    }
}
[Serializable]
public enum LetterType{
    A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
}
