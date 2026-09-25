using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private GameObject startScreenPanel;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cannonSpawner;
    [SerializeField] private AudioSource startScreenLoop;
    [SerializeField] private AudioSource oceanAmbience;

    private void Awake()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
        cannonSpawner.SetActive(false);

        startScreenLoop.Play();
    }

    public void StartGame()
    {
        startScreenLoop.Stop();
        oceanAmbience.Play();

        Time.timeScale = 1f;
        startScreenPanel.SetActive(false);
        player.SetActive(true);
        cannonSpawner.SetActive(true);
    }
}