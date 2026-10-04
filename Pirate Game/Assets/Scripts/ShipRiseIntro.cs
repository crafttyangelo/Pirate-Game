using UnityEngine;

public class ShipRiseIntro : MonoBehaviour

{
    //How fast it travels upward
    public float speed = 4f; 
    //final destination before stopping 
    public float targetY = 0f;
    //the playable ship
    public GameObject playableShip;
    public GameObject cannonSpawner;
    void Update()
    {
        if (transform.position.y < targetY)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            playableShip.SetActive(true);
            cannonSpawner.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
