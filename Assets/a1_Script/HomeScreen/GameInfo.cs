using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    [field: SerializeField] public string GameTitle { get; private set; }
    [field: SerializeField] public string GameSceneName { get; private set; }
    [TextArea]
    [SerializeField] private string gameDescription;
    public string GameDescription { get => gameDescription; }

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
