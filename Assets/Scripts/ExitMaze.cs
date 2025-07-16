using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMaze : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            Debug.Log("Player reached the exit!");

            // Set the game result to "Win"
            ResultMenu.lastResult = ResultMenu.GameResult.Win;

            // Load the Result Scene
            SceneManager.LoadScene("Result"); // Change this to your actual Result Scene name
        }
    }
}
