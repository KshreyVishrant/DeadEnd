using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.SceneManagement;

public class ResultMenu : MonoBehaviour
{
    public TextMeshProUGUI resultText; // Assign the "ResultText" object here

    public enum GameResult { Win, TimeOut, Death }
    public static GameResult lastResult; // Tracks the outcome

    void Start()
    {
        // Set the text based on the game result
        switch (lastResult)
        {
            case GameResult.Win:
                resultText.text = "VICTORY!"; 
                break;
            case GameResult.TimeOut:
                resultText.text = "TIME'S UP!";
                break;
            case GameResult.Death:
                resultText.text = "WASTED!";
                break;
        }
    }

    public void OnRetryClick()
    {
        SceneManager.LoadScene("Game"); // Reload the game scene
    }

    public void OnExitClick()
    {
        //SceneManager.LoadScene("Main Menu"); // Return to main menu

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }
}