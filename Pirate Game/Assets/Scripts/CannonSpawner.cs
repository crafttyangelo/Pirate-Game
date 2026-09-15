using UnityEngine;

public class CannonSpawner : MonoBehaviour
{

    public Camera cam;
    public GameObject cannon;
    private float spawn_timer = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void SpawnCannon()
    {
        GameObject new_cannon = Instantiate(cannon);
        int x_pos;
        int y_pos;

        // 50% chance to spawn at the sides or at the top/bottom

        if ( Random.value < 0.5f ) // Spawn Left
        {
            x_pos = 0;
        }
        else // Spawn right
        {
            x_pos = cam.scaledPixelWidth;
            y_pos = Random.Range(0, cam.scaledPixelHeight);
        }
    }
}
