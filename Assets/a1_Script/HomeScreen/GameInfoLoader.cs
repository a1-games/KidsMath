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
    [SerializeField] private Button viewGameStatsButton;

    private void Start()
    {
        playThisGameButton.onClick.AddListener(() => {
            // 2 load scene
            SceneLoader.LoadScene(GlobalVariables.SelectedGameInfo.Game.ToString());
        });
        viewGameStatsButton.onClick.AddListener(() => {
            // load stats
            StatsLoader.AskFor.LoadGameStatsInDifficulty(GlobalVariables.SelectedGameInfo);
        });
    }

    public void ShowGameInfo(GameInfo_SO gameInfo)
    {
        gameTitle.text = gameInfo.GameTitle[GlobalVariables.AppLanguage];
        gameDescription.text = gameInfo.GameDescription[GlobalVariables.AppLanguage];
        gameThumbnail.sprite = gameInfo.GameThumbnail;

        gameInfoPanel.SetActive(true);

        GlobalVariables.SelectedGameInfo = gameInfo;
    }


}
