using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    [SerializeField] GameObject letterPrefab;

    public void SpawnLetter(string letter)
    {
        Letter letterSpawn = Instantiate(letterPrefab, transform).GetComponent<Letter>();
        letterSpawn.SetLetter((LetterType)(letter[0] - 'A'));
    }
}
