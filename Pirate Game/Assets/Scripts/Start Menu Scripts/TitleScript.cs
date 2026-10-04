using UnityEngine;

public class TitleScript : MonoBehaviour
   {
    public Sprite[] frames;

    int current = 0;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = frames[0];
    }

    public void NextFrame()
    {
        if (current < frames.Length - 1)
        {
            current++;
            sr.sprite = frames[current];
        }
    }
   }

