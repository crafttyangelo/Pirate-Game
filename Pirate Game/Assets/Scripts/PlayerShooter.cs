using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public AudioClip fireSound;
    public float cannonballSpeed = 3f;
    public float fireCooldown = 2f;

    float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireCooldown;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        Vector2 direction = (mouseWorld - transform.position).normalized;

        Vector3 spawnPos = transform.position + (Vector3)(direction * 0.7f);
        GameObject ball = Instantiate(cannonballPrefab, spawnPos, Quaternion.identity);

        ball.GetComponent<Rigidbody2D>().linearVelocity = direction * cannonballSpeed;

        if (fireSound != null)
            AudioSource.PlayClipAtPoint(fireSound, transform.position);

        Destroy(ball, 10f);
    }
}
