using UnityEngine;

public class ShootingShipSpawner : MonoBehaviour
{

    public Camera cam;
    public GameObject shootingShip;

    public AudioSource audioSource;
    public AudioClip maybeSoundHere;
    private float spawn_timer = 5f;
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
            spawn_timer = Random.Range(15f,25f);
            SpawnSS();
        }
    }
    

    private void SpawnSS()
    {
        GameObject new_cannon = Instantiate(shootingShip);
        audioSource.pitch = Random.Range(1f, 1f);
        audioSource.PlayOneShot(maybeSoundHere);
        new_cannon.transform.position = new Vector2(13.5f, 4.2f); 
    }
}
