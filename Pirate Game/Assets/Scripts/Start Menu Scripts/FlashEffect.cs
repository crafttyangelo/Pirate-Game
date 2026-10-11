using UnityEngine;
using System.Collections;

public class FlashEffect : MonoBehaviour
{
    public GameObject WhiteFlash;
    public AudioSource FlashSound;
    public TitleScript title;
    //time the screen stays white for.
    public float flashTime = .25f;
    
    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        WhiteFlash.SetActive(true);
        FlashSound.Play();
        title.NextFrame();
        yield return new WaitForSeconds(flashTime);
        WhiteFlash.SetActive(false);
    }
}
