using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameObject difficultySelection_Panel;
    [SerializeField] private TMP_Text difficultyIndicator;
    [SerializeField] private ScriptableObject[] gameDifficulies;

    private void Start()
    {
        difficultySelection_Panel.SetActive(true);
    }
    public void SetDifficulty(int level)
    {
        difficultySelection_Panel.SetActive(false);
        difficultyIndicator.text = level.ToString();
        gameSettings.SetDifficultySO(gameDifficulies[level-1], level);
    }
}
