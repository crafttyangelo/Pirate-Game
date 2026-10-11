using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public GameObject object_to_spawn;
    public float spawnTimer;
    public AudioSource audioSource;
    public AudioClip objectSound;
    //public float speed = 3;
    //public int damage = 1;

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
            spawnTimer = 1f;
            Spawn();
        }
    }
    private void Spawn()
    {
        GameObject new_object = Instantiate(object_to_spawn, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(objectSound);
        
    }

}
