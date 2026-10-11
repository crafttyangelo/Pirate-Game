using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MenuAppear : MonoBehaviour
{
    //gives me a box to put any object I want to appear after the timeframe (on my menuappearer game object).
    public GameObject[] ObjectsToReveal;
    public float delay = 6.5f;
    void Start()
    {
    StartCoroutine(ActivateObjects());
    }

    IEnumerator ActivateObjects()
    {
        yield return new WaitForSeconds (delay);

        foreach (GameObject obj in ObjectsToReveal)
        {
            if (obj != null)
                obj.SetActive(true);
        }
        
    }
}
