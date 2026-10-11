using UnityEngine;

public class MoveUpTitle : MonoBehaviour

{
    //How fast it travels upward
    public float speed = 8f; 
    //final destination before stopping 
    public float targetY = -1f;
    //time to wait before rising
    public float delay = 3f; //in seconds
    private float Frame = 0f;
    public FlashEffect flash;

    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        //makes timer increase with time and once it is equal or greater than the delay the code will run.
        timer += Time.deltaTime;
        if (timer < delay) return;

        if (transform.position.y < targetY)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            flash.Flash();
            gameObject.SetActive(false);
        }
    }
}
