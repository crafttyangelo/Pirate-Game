using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    void OnMouseDown()
    {
        QuitGame();
    }
}


