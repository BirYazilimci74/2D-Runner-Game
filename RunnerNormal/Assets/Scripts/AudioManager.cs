using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip jump;
    
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClickAudio()
    {
        audioSource.PlayOneShot(buttonClick);
    }
    
    public void GameOverAudio()
    {
        audioSource.PlayOneShot(gameOver);
    }
    
    public void JumpAudio()
    {
        audioSource.PlayOneShot(jump);
    }
}
