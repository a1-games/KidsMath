using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public void ShowGameInfo(GameInfo gameInfo)
    {
        gameInfoPanel.SetActive(true);
        gameTitle.text = gameInfo.GameTitle;
        gameDescription.text = gameInfo.GameDescription;
        gameThumbnail.sprite = gameInfo.GameThumbnail;
        playThisGameButton.onClick.RemoveAllListeners();
        playThisGameButton.onClick.AddListener(() => {
            // loadscene gameInfo.GameSceneName
        });
    }


}
