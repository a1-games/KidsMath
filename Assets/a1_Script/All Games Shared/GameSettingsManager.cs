using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameObject difficultySelection_Panel;
    [SerializeField] private ScriptableObject[] gameDifficulies;

    public void SetDifficulty(int level)
    {
        difficultySelection_Panel.SetActive(false);
        gameSettings.SetDifficultySO(gameDifficulies[level-1]);
    }
}
