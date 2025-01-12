using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordLibrarySO", menuName = "Scriptable Objects/WordLibrarySO")]
public class WordLibrarySO : ScriptableObject
{
    public List<string> library;
}
