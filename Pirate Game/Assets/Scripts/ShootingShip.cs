using UnityEngine;

public class shootingShip : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 3;
    public int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get Component
        rb = GetComponent<Rigidbody2D>();

        // Set Direction
        direction = Vector2.left;

        // Add a force to the bullet
        rb.AddForce(direction * speed, ForceMode2D.Impulse);

        // Destroy cannon
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
