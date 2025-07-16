using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    //public AudioSource GameMusic;

    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;

        //if (GameMusic == null)
        //{
        //    GameMusic = FindObjectOfType<AudioSource>();
        //    if (GameMusic == null)
        //    {
        //        Debug.LogWarning("No game music audio source found");
        //    }
        //}

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        //AudioListener.pause = true;

        //if (GameMusic != null)
        //{
        //    GameMusic.Pause();
        //}

    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //AudioListener.pause = false;

        //if (GameMusic != null)
        //{
        //    GameMusic.UnPause();
        //}

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Unpause time
        SceneManager.LoadScene("Main Menu"); // Replace with your main menu scene name
    }

    public void QuitGame()
    {
        Application.Quit(); // Works in built game (not in Editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // For testing in Editor
#endif
    }
}








//using System.Collections;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PauseMenu : MonoBehaviour
//{
//    public GameObject pauseMenu;
//    public static bool isPaused;

//    void Start()
//    {
//        pauseMenu.SetActive(false);
//        isPaused = false;
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            TogglePause();
//        }
//    }

//    public void TogglePause()
//    {
//        if (isPaused)
//        {
//            pauseMenu.SetActive(false);
//            Time.timeScale = 1f;
//        }
//        else
//        {
//            pauseMenu.SetActive(true);
//            Time.timeScale = 0f;
//        }
//        isPaused = !isPaused;
//    }

//    public void GoToMainMenu()
//    {
//        Time.timeScale = 1f;
//        SceneManager.LoadScene("Main Menu");
//    }

//    public void QuitGame()
//    {
//        Application.Quit();
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
//    }
//}
