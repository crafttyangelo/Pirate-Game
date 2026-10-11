using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] healthSprites = new Sprite[6];

    public void SetHealth(int health)
    {
        int frameIndex = Mathf.Clamp(5 - health, 0, 5);
        GetComponent<SpriteRenderer>().sprite = healthSprites[frameIndex];
    }
}