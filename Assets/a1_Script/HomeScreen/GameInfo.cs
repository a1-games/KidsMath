using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    [field: SerializeField] public GameInfo_SO GameInfoSO { get; private set; }
    [field: SerializeField] public Image GameThumbnail_Image { get; private set; }

    [SerializeField] private Button openGameInfo_Button;

    private void Awake()
    {
        openGameInfo_Button.onClick.RemoveAllListeners();
        openGameInfo_Button.onClick.AddListener(() => GameInfoLoader.AskFor.ShowGameInfo(GameInfoSO));

        GameThumbnail_Image.sprite = GameInfoSO.GameThumbnail;
    }
}
