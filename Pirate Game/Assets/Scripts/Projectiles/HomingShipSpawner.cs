using UnityEngine;

public class HomingShipSpawner : MonoBehaviour
{

    public Camera cam;
    public GameObject homingShip;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private float spawn_timer = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn cannons
        spawn_timer -= Time.deltaTime;
        if(spawn_timer <= 0)
        {
            spawn_timer = Random.Range(5f,10f);
            SpawnHomingShip();
        }
    }
    

    private void SpawnHomingShip()
    {
        GameObject new_cannon = Instantiate(homingShip);
        audioSource.pitch = Random.Range(1f, 1f);
        audioSource.PlayOneShot(soundEffect);
        int x_pos;
        int y_pos;

        // 50% chance to spawn at the sides or at the top/bottom

        if (Random.value < 0.5f)
        {
            if (Random.value < 0.5f) // Spawn left
            {
                x_pos = -100;
            }
            else // Spawn right
            {
                x_pos = cam.scaledPixelWidth +100;

            }
            // Random y value to spawn     
            y_pos = Random.Range(0, cam.scaledPixelHeight);

        }
        else
        {
            if (Random.value < 0.5f) // Spawn bottom
            {
                y_pos = -100;
            }
            else
            {
                y_pos = cam.scaledPixelHeight +100;
            }
            x_pos = Random.Range(0,cam.scaledPixelWidth);
        }

        // Convert to world position
        Vector3 spawn_point = new Vector3(x_pos, y_pos, 0);
        spawn_point = cam.ScreenToWorldPoint(spawn_point);
        spawn_point.z = 0;

        // Position the cannon
        new_cannon.transform.position = spawn_point;
    }
}
