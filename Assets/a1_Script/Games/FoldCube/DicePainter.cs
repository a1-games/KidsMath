using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

[Serializable]
public struct ColourblindColor
{
    public Color Color;
    public Texture2D Shape;
}






public class DicePainter : MonoBehaviour
{
    private static DicePainter instance;
    public static DicePainter AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    private ColourblindColor[] randomizedColors = new ColourblindColor[6];

    private Cube[] foldedCubes { get => FoldCubeManager.AskFor.FoldedCubes; }

    public void ApplyColor(ColourblindColor colorPair, CubeSide cubeSide)
    {
        cubeSide.CColor = colorPair;

        cubeSide._Mesh.material.color = colorPair.Color;
        if (FoldCube_GameSettings.AskFor.ApplyColourblindness)
            cubeSide._Mesh.material.mainTexture = colorPair.Shape;
    }

    public void ApplyCubeColors(Cube cube)
    {
        ApplyColor(randomizedColors[0], cube.Top);
        ApplyColor(randomizedColors[1], cube.Front);
        ApplyColor(randomizedColors[2], cube.Right);
        ApplyColor(randomizedColors[3], cube.Bottom);
        ApplyColor(randomizedColors[4], cube.Back);
        ApplyColor(randomizedColors[5], cube.Left);
    }


    public void SetChoiceCubesHalf(int correctCube)
    {
        int frontRightLeft = 0;

        ApplyCubeColors(foldedCubes[correctCube]);

        for (int i = 0; i < foldedCubes.Length; i++)
        {
            if (i == correctCube) continue;

            ApplyCubeColors(foldedCubes[i]);

            // switch two colours around so they aren't exactly the same as the correct cube

            if (frontRightLeft == 0)
            {
                ApplyColor(foldedCubes[i].Bottom.CColor, foldedCubes[i].Top);
            }
            if (frontRightLeft == 1)
            {
                ApplyColor(foldedCubes[i].Left.CColor, foldedCubes[i].Right);
            }
            if (frontRightLeft == 2)
            {
                ApplyColor(foldedCubes[i].Back.CColor, foldedCubes[i].Front);
            }

            frontRightLeft++;
        }
    }

    public void SetChoiceCubesFull(int correctCube)
    {
        int frontRightLeft = 0;

        ApplyCubeColors(foldedCubes[correctCube]);

        for (int i = 0; i < foldedCubes.Length; i++)
        {
            if (i == correctCube) continue;

            ApplyCubeColors(foldedCubes[i]);

            // switch two colours around so they aren't exactly the same as the correct cube

            if (frontRightLeft == 0)
            {
                var tmpCC = foldedCubes[i].Top.CColor;
                ApplyColor(foldedCubes[i].Bottom.CColor, foldedCubes[i].Top);
                ApplyColor(tmpCC, foldedCubes[i].Bottom);
            }
            if (frontRightLeft == 1)
            {
                var tmpCC = foldedCubes[i].Right.CColor;
                ApplyColor(foldedCubes[i].Left.CColor, foldedCubes[i].Right);
                ApplyColor(tmpCC, foldedCubes[i].Left);
            }
            if (frontRightLeft == 2)
            {
                var tmpCC = foldedCubes[i].Front.CColor;
                ApplyColor(foldedCubes[i].Back.CColor, foldedCubes[i].Front);
                ApplyColor(tmpCC, foldedCubes[i].Back);
            }

            frontRightLeft++;
        }
    }


    public void RandomizeColorList()
    {
        List<int> numbers = new List<int>() { 0,1,2,3,4,5 };

        for (int i = 0; i < 6; i++)
        {
            var rndNr = UnityEngine.Random.Range(0, numbers.Count);

            var t = FoldCube_GameSettings.AskFor.SixColors[numbers[rndNr]];
            randomizedColors[i] = t;
            numbers.RemoveAt(rndNr);
        }
    }

}
