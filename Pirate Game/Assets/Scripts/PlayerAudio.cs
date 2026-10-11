using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shipDamageAudio; // Ship getting hit splice
    public AudioClip beginAudio; // All aboard splice
    public AudioClip loserAudio; // Lose splice
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShipDamage()
    {
        audioSource.PlayOneShot(shipDamageAudio);
    }

    public void loseSound()
    {
        audioSource.PlayOneShot(loserAudio);
    }

    public void startSound()
    {
        audioSource.PlayOneShot(beginAudio);
    }
}
