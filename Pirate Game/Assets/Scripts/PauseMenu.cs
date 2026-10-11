using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPaused;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (isPaused)
        {
            Resume();
        }
        else if (Time.timeScale > 0f)
        {
            // Avoid opening pause over the existing start screen.
            Pause();
        }
    }

    private void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        if (isPaused)
            Resume();
    }
}