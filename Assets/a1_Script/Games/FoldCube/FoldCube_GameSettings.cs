using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldCube_GameSettings : GameSettings
{
    private static FoldCube_GameSettings instance;
    public static FoldCube_GameSettings AskFor { get => instance; }

    [SerializeField] private FoldCube_GameSettings_SO _gameSettings_SO;


    private bool applyColourblindness;
    public bool ApplyColourblindness { get => applyColourblindness; }

    private ColourblindColor[] sixColors;
    public ColourblindColor[] SixColors { get => sixColors; }

    private void Awake()
    {
        instance = this;
        CopySettingsFromSO();
    }

    protected override void CopySettingsFromSO()
    {
        applyColourblindness = _gameSettings_SO.ApplyColourblindness;
        sixColors = _gameSettings_SO.SixColors;
    }


    public override void SetDifficultySO(ScriptableObject GameSettings_SO, int difficulty)
    {
        _gameSettings_SO = GameSettings_SO as FoldCube_GameSettings_SO;
        base.SetDifficultySO(GameSettings_SO, difficulty);
    }

}
