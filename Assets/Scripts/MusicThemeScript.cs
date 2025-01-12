using UnityEngine;

public class MusicThemeScript : MonoBehaviour
{
    public AudioClip[] musicList;
    public AudioSource audioSource;
    int musicIndex = 0;

    void Start()
    {
        if (musicList.Length > 0)
        {
            audioSource.clip = musicList[musicIndex];
            audioSource.Play();
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            musicIndex++;
            if (musicIndex >= musicList.Length)
            {
                musicIndex = 0;
            }

            audioSource.clip = musicList[musicIndex];
            audioSource.Play();
        }
    }
}
