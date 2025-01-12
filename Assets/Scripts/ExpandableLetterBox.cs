using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ExpandableLetterBox : MonoBehaviour, IDropHandler
{
    [SerializeField] private LetterSettingsSO cellSize;
    [SerializeField] private LetterSettingsSO letterSize;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private int columns;
    [SerializeField] private string word;
    [SerializeField] private GameObject checkBox;
    private int amountOfChildern;
    private void Start()
    {
        gridLayoutGroup.cellSize = new Vector2(letterSize.cellSize, letterSize.cellSize);
        rectTransform.sizeDelta = new Vector2(cellSize.cellSize* columns, cellSize.cellSize);
        var rect = rectTransform.rect;
        Vector3 pos = rectTransform.position;
        pos.x += cellSize.cellSize * (columns/2 + 1);
        RectTransform box = checkBox.GetComponent<RectTransform>();
        box.SetPositionAndRotation(pos, Quaternion.identity);
        box.sizeDelta = new Vector2(cellSize.cellSize, cellSize.cellSize);
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

    public String GetWord()
    {
        return word;
    }
}
