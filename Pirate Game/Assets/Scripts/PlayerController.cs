using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;
    public float acceleration = 10f;
    public float decceleration = 5f;
    public float maxSpeed = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1; 
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else
        {
            direction.x = 0;
        }

        // Vertical Movement
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        else
        {
            direction.y = 0;
        }

        direction = direction.normalized;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, (Vector3)direction);
    }

    private void FixedUpdate()
    {   // If player is moving
        if (direction != Vector2.zero)
        {
            // Move player (Sluggish Movement)
            rb.AddForce(rb.position + (direction * acceleration), ForceMode2D.Force);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }        
            // If no input, then apply decceleration
            else
            {
                rb.AddForce(rb.linearVelocity * -decceleration, ForceMode2D.Force);
            }
        }

            /* Original Move Player
            rb.MovePosition(rb.position + (direction * speed * Time.fixedDeltaTime));
            */
    }
}
