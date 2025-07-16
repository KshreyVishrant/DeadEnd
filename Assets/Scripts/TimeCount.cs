using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime = 180f; // Set starting time in seconds
    private bool timeExpired = false;

    void Update()
    {
        if (PauseMenu.isPaused) return; // Don't count down while paused

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (!timeExpired)
        {
            remainingTime = 0;
            timeExpired = true;
            OnTimeExpired();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        // Visual warning when time is low
        if (remainingTime < 10f)
        {
            timerText.color = Color.red;
            // Optional: Add blinking effect here
        }
    }

    void OnTimeExpired()
    {
        // Trigger timeout result
        ResultMenu.lastResult = ResultMenu.GameResult.TimeOut;
        SceneManager.LoadScene("Result");

        // Optional: Play timeout sound
        // AudioSource.PlayClipAtPoint(timeoutSound, Camera.main.transform.position);
    }

    // Call this to add bonus time (optional)
    public void AddTime(float bonusSeconds)
    {
        remainingTime += bonusSeconds;
    }
}