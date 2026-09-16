using UnityEngine;

public class CannonBall : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get Component
        rb = GetComponent<Rigidbody2D>();

        // Set Direction
        GameObject player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        direction = direction.normalized;

        // Add a force to the bullet
        rb.AddForce(direction * speed, ForceMode2D.Impulse);

        // Destroy cannon
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
