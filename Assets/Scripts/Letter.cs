using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private LetterSettingsSO letterSettings;
    [SerializeField] private Image image;
    [SerializeField] List<Sprite> letterSprites;
    [SerializeField] private LetterType letter;

    public void Start()
    {
        rectTransform.sizeDelta = new Vector2(letterSettings.cellSize, letterSettings.cellSize);
        SetLetter(letter);
    }

    public void SetLetter(LetterType letterType)
    {
        letter = letterType;
        image.sprite = letterSprites[(int) letterType];
    }

    public string GetLetter()
    {
        return letter.ToString();
    }
}
[Serializable]
public enum LetterType{
    A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
}
