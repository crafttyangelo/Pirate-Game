using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPauseScreen : MonoBehaviour
{
    // For the pause menu screen, the Exit button takes you back to the starting screen.
     void OnMouseDown()
{
    SceneManager.LoadScene("Start Screen");
}

}
