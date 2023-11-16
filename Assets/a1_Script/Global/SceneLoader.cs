
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private Slider loadingBar;

    [SerializeField] private TMP_Text loadingText;


    private void LoadSceneReset()
    {
        Time.timeScale = 1f;
        loadingScreen.SetActive(true);
    }


    public static void LoadScene(string sceneName)
    {
        instance.LoadSceneReset();
        instance.LoadLevel(sceneName);
    }
    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadSceneAsync(levelName));
    
    }
    IEnumerator LoadSceneAsync(string levelName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);//Debug.Log(op.progress);
            loadingBar.value = progress;
            //                 (int) to make it a whole number
            loadingText.text = (int)(progress * 100f) + "";
            yield return null;
        }
        loadingScreen.SetActive(false);
    }


    public static void LoadScene(int sceneIndex)
    {
        instance.LoadSceneReset();
        instance.LoadLevel(sceneIndex);
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));

    }
    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);//Debug.Log(op.progress);
            loadingBar.value = progress;
            //                 (int) to make it a whole number
            loadingText.text = (int)(progress * 100f) + "";
            yield return null;
        }
        loadingScreen.SetActive(false);
    }

}
