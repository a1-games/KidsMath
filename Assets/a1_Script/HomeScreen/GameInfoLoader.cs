using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInfoLoader : MonoBehaviour
{
    private static GameInfoLoader instance;
    public static GameInfoLoader AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject gameInfoPanel;

    [SerializeField] private TMP_Text gameTitle;
    [SerializeField] private TMP_Text gameDescription;

    [SerializeField] private Image gameThumbnail;
    [SerializeField] private Button playThisGameButton;

    [SerializeField] private GameObject loadingScreen;

    public void ShowGameInfo(GameInfo gameInfo)
    {
        gameTitle.text = gameInfo.GameTitle;
        gameDescription.text = gameInfo.GameDescription;
        gameThumbnail.sprite = gameInfo.GameThumbnail;
        playThisGameButton.onClick.RemoveAllListeners();
        playThisGameButton.onClick.AddListener(() => {
            // 1 show loading screen
            loadingScreen.SetActive(true);
            // 2 load scene
            SceneManager.LoadSceneAsync(gameInfo.GameSceneName);
        });
        gameInfoPanel.SetActive(true);
    }


}
