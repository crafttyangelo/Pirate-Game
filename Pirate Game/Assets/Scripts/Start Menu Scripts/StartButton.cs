using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("Main Game");
    }
    void OnMouseDown()
    {
        LoadSceneByName();
    }
   
}
