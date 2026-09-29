using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;
    private PlayerAudio shipAudio; // Referencing PlayerAudio script and making it a local variable

    [Header("Movement")]
    public float acceleration = 10f;
    public float decceleration = 5f;
    public float maxSpeed = 20f;

    [Header("Miscellaneous")]
    public int health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Grab audio component 
        shipAudio = GetComponent<PlayerAudio>();

        // Plays all aboard splice
        shipAudio.startSound();
    }

    #region Input
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
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, (Vector3)direction);
    }*/
    #endregion
    private void OnCollisionEnter2D(Collision2D ball)
    {
        // Check if ship collides with cannon balls
        if (ball.gameObject.layer == LayerMask.NameToLayer("Cannon Balls"))
        
        {
            //Turn ship red
            GetComponent <SpriteRenderer>().color = Color.red;
            StartCoroutine(ColorNormal());

            // Get CannonBall script attached to the cannonball that collided with player
            CannonBall script = ball.gameObject.GetComponent<CannonBall>();

            // Checks to see if CannonBall script exists
            if (script != null)
            {
                health -= script.damage; // Access damage variable from CannonBall script        
            }

            // Checks to see if PlayerAudio script exists
            if (shipAudio != null)
            {
                shipAudio.ShipDamage(); // Play damage sound
            }

            if (health <= 0)
            {
                Lose();
            }

            // Destroy cannon ball once triggered with boat
            Destroy(ball.gameObject);      
        }
    }

    private void Lose()
    {
        shipAudio.loseSound();
    }

    IEnumerator ColorNormal()
    {
        // Wait for 0.25s
        yield return new WaitForSeconds(0.25f);

        // Turn sprite back to normal color.
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    #region Rotation and Movement 
    private void FixedUpdate()
    {   // If player is moving
        if (direction != Vector2.zero)
        {
            // Move player (Sluggish Movement)
            rb.AddForce((direction * acceleration), ForceMode2D.Force);

            // Calculate angle of movement in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply rotation according to input (A turns ship to left)
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }

        // If no input, then apply decceleration
        else
        {
            rb.AddForce(rb.linearVelocity * -decceleration, ForceMode2D.Force);
        }
        

            /* Original Move Player
            rb.MovePosition(rb.position + (direction * speed * Time.fixedDeltaTime));
            */
    }
    #endregion
}
