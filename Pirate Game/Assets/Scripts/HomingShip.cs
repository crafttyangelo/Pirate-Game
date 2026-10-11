using UnityEngine;

public class HomingShip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    Rigidbody2D rb;
    public float speed = 2f;
    public int damage = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Sets the target to the player on spawn (cant set the player to the target in the prefab for some reason)
        if (target == null)
        {
            GameObject player = GameObject.Find("Player");
            target = player.transform;
            
        }

        Destroy(this.gameObject, 10);
    }
//makes it so it destroyed on hit
        private void OnCollisionEnter2D(Collision2D ball)
{
    if (ball.gameObject.layer == LayerMask.NameToLayer("Player Cannon Ball"))
    {
        Debug.Log ("yo");
        Destroy(ball.gameObject);
        Destroy(gameObject);         
    }
}

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed = Time.deltaTime);
    }
}
