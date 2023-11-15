using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject pauseScreen;


    public void PauseGame(bool paused = true)
    {
        if (paused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }


    public void GoToHomeScreen()
    {
        // show loading first
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync("HomeScreen");
    }
}
