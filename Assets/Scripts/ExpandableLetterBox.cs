using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExpandableLetterBox : MonoBehaviour, IDropHandler
{
    [SerializeField] private LetterSettingsSO settings;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private int columns;
    [SerializeField] private string word;
    private int amountOfChildern;
    private void Start()
    {
        gridLayoutGroup.cellSize = new Vector2(settings.cellSize, settings.cellSize);
        rectTransform.sizeDelta = new Vector2(settings.cellSize* columns, settings.cellSize);
    }

    public void OnDrop(PointerEventData eventData)
    {
        
        if (transform.childCount < columns)
        {
            GameObject dropped = eventData.pointerDrag;
            Letter letter = dropped.GetComponent<Letter>();
            if (letter != null)
            {
                DragDrop drag = dropped.GetComponent<DragDrop>();
                drag.SetParentAfterDrag(transform);
            }
        }
        
    }

    private void Update()
    {
        if (amountOfChildern != transform.childCount)
        {
            StringBuilder sb = new StringBuilder();
            Letter[] children = transform.GetComponentsInChildren<Letter>();

            foreach (var letter in children)
            {
                sb.Append(letter.GetLetter());
            }
            word = sb.ToString();
            amountOfChildern = transform.childCount;
        }
        
    }
}
