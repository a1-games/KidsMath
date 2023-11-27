using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    [SerializeField] private Translation_SO gameTitle;
    public string GameTitle { get => gameTitle[GlobalVariables.AppLanguage]; }

    [field: SerializeField] public MyGames Game { get; private set; }

    [SerializeField] private Translation_SO gameDescription;
    public string GameDescription { get => gameDescription[GlobalVariables.AppLanguage]; }

    [field: SerializeField] public Sprite GameThumbnail { get; private set; }
    [field: SerializeField] public Image GameThumbnail_Image { get; private set; }

    [SerializeField] private Button openGameInfo_Button;

    private void Awake()
    {
        openGameInfo_Button.onClick.RemoveAllListeners();
        openGameInfo_Button.onClick.AddListener(() => GameInfoLoader.AskFor.ShowGameInfo(this));

        GameThumbnail_Image.sprite = GameThumbnail;
    }
}
