using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    [SerializeField] GameObject letterPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Letter letter = Instantiate(letterPrefab, transform).GetComponent<Letter>();
            letter.SetLetter(Random.Range(0, 25));
        }
        
    }
}
