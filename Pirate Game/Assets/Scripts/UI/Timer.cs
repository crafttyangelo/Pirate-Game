using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; // Using this namespace for Timespan, converting seconds to minutes

public class Timer : MonoBehaviour
{
    [Header("Time")]
    private float gameTime = 0; // Seconds
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        // Time goes up in real time
        gameTime += Time.deltaTime;

        // Creates a variable and stores the time inside
        TimeSpan uiTime = TimeSpan.FromSeconds(gameTime);

        // Converts the uiTime variable into a string to relay inside the game
        string uiFixedTime = uiTime.ToString(@"m\:ss");

        // Logic for player winning if they survive for 3.5 minutes
        if (gameTime >= 210)
        {
            SceneManager.LoadScene("Win Screen");
        }

        // Displays time in the game 
        timeText.text = "Time: " + uiFixedTime;
    }
}
