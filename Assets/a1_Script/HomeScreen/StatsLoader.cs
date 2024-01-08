using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct StatTextPair
{
    public TMP_Text wins;
    public TMP_Text losses;
}


public class StatsLoader : MonoBehaviour
{
    private static StatsLoader instance;
    public static StatsLoader AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject statsPanel;
    [SerializeField] private TMP_Text gameTitle_Text;
    [SerializeField] private Image gameThumbnail;
    [SerializeField] private StatTextPair[] difficultyStats_Texts;




    public void LoadGameStatsInDifficulty(GameInfo_SO gameInfo)
    {
        if (difficultyStats_Texts.Length != 5) throw new Exception("There must be 5 difficulties defined in the array in the inspector!");
        gameTitle_Text.text = gameInfo.GameTitle[GlobalVariables.AppLanguage];
        gameThumbnail.sprite = gameInfo.GameThumbnail;

        statsPanel.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            var wins = GameSave.GetSavedGameInt(gameInfo.Game, i, true);
            var losses = GameSave.GetSavedGameInt(gameInfo.Game, i, false);

            difficultyStats_Texts[i].wins.text = wins.ToString();
            difficultyStats_Texts[i].losses.text = losses.ToString();
        }
    }



    public string GetTranslation(SupportedLanguages lang)
    {
        return "";
    }
}
