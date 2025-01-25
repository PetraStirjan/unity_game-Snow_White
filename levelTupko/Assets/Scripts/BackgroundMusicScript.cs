using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioClip backgroundClip; // Pozadinska melodija (npr. mario.wav)
    public AudioClip coinClip;       // Zvuk za novčić (npr. coin.wav)

    private AudioSource audioSource;

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();

        
        if (backgroundClip != null)
        {
            audioSource.clip = backgroundClip;
            audioSource.loop = true; 
            audioSource.Play();
        }
    }

    public void PlayCoinSound()
    {
        if (coinClip != null)
        {
            audioSource.PlayOneShot(coinClip);
        }
    }
    
   
}
