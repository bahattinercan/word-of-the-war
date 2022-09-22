using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]private AudioClip winSound;
    [SerializeField]private AudioClip loseSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();        
        GameController.instance.OnGameFinished += OnGameFinished;
    }

    private void OnGameFinished(bool isPlayerWin)
    {
        audioSource.loop = false;
        if (isPlayerWin)
            audioSource.clip = winSound;
        else
            audioSource.clip = loseSound;
        audioSource.Play();
    }
}