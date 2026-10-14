using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shipDamageAudio; // Ship getting hit splice
    public AudioClip beginAudio; // All aboard splice
    public AudioClip loserAudio; // Lose splice
    public AudioClip oceanBackground; // Ocean ambience sound

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OceanSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OceanSound()
    {
        audioSource.clip = oceanBackground;
        audioSource.loop = true;
        audioSource.Play();
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
