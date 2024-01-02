using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoldCubeManager : GameManager
{
    private static FoldCubeManager instance;
    public static FoldCubeManager AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    // the main fouldout
    [field: SerializeField] public Cube FoldoutCube { get; private set; }
    // full dice
    [field: SerializeField] public Cube[] FoldedCubes { get; private set; } = new Cube[4];

    [SerializeField] private UnityEvent OnCubeClicked;

    public int CorrectCube { get; private set; } = -1;
    private bool canClick = false;


    public override void StartGame()
    {
        RerollCube();
        canClick = true;
    }

    public override void ResetGame()
    {
        canClick = false;
    }

    private void RerollCube()
    {
        DicePainter.AskFor.RandomizeColorList();
        CorrectCube = UnityEngine.Random.Range(0, FoldedCubes.Length);
        DicePainter.AskFor.ApplyCubeColors(FoldCubeManager.AskFor.FoldoutCube);
        DicePainter.AskFor.SetChoiceCubesHalf(CorrectCube);
    }


    public void CubeClick(RaycastHit hit)
    {
        if (!canClick) return;

        var cubeScript = hit.transform.gameObject.GetComponent<Cube>();

        if (cubeScript == FoldedCubes[CorrectCube])
        {
            CorrectAnswer();
        }
        else
        {
            IncorrectAnswer();
        }
        canClick = false;
    }


    protected override void CorrectAnswer()
    {
        EmotePanel.AskFor.ShowCorrect();
        GameSave.IncreaseSavedGameInt(MyGames.FoldCube, FoldCube_GameSettings.AskFor.Difficulty, true, 1);
    }


    protected override void IncorrectAnswer()
    {
        EmotePanel.AskFor.ShowIncorrect();
        GameSave.IncreaseSavedGameInt(MyGames.FoldCube, FoldCube_GameSettings.AskFor.Difficulty, false, 1);
    }

}
