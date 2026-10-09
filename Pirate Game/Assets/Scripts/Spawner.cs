using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public GameObject GameObject;
    public float spawnTimer;
    public AudioSource audioSource;
    public AudioClip objectSound;
    public float speed = 3;
    public int damage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer = Random.Range(1f,5f);
            Spawn();
        }
    }
    private void Spawn()
    {
        GameObject = Instantiate(GameObject);
        audioSource.PlayOneShot(objectSound);
        rb = GetComponent<Rigidbody2D>();

        // Set Direction
        //direction = Vector2.down;

        // Add a force to the bullet
        rb.AddForce(direction * speed, ForceMode2D.Impulse);

        // Destroy cannon
        Destroy(this.GameObject, 10);
    }

}
