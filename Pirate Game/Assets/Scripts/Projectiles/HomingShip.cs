using UnityEngine;

public class HomingShip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    Rigidbody2D rb;
    public float speed = 2f;
    public int damage = 1;
    public AudioClip shipDestroyedSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Sets the target to the player on spawn (cant set the player to the target in the prefab for some reason)
        if (target == null)
        {
            GameObject player = GameObject.Find("Player");
            target = player.transform;
            
        }

        //Destroy(this.gameObject, 30);
    }
//makes it so it destroyed on hit
        private void OnCollisionEnter2D(Collision2D ball)
{

    if (ball.gameObject.layer == LayerMask.NameToLayer("Player Cannon Ball"))
    {
        if (shipDestroyedSound != null)
        {
            AudioSource.PlayClipAtPoint(shipDestroyedSound, transform.position);
        }

        Destroy(ball.gameObject);
        Destroy(gameObject);         
    }
}

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        //gets the diretion towards the player so the ship can face it
        Vector2 direction = (target.position - transform.position).normalized;
        //Move the ship towardws the player
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed = Time.deltaTime);
        //roates the ship so it faces in the direction it is traveling towards
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
