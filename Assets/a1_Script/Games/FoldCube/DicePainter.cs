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

    [SerializeField] private bool applyColourblindness;

    [SerializeField]
    private ColourblindColor[] sixColors = new ColourblindColor[6];

    // the main fouldout
    [SerializeField] private Cube foldoutCube;
    // full dice
    [SerializeField] private Cube[] foldedCubes = new Cube[4];
    // only 3 of the sides
    [SerializeField] private HalfCube[] halfCubes = new HalfCube[4];


    private ColourblindColor[] randomizedColors = new ColourblindColor[6];

    public int CorrectCube { get; private set; } = -1;

    private void Start()
    {
        RandomizeColorList();
        ApplyCubeColors(foldoutCube);
        SetChoiceCubes();
    }

    private void ApplyColor(ColourblindColor colorPair, CubeSide cubeSide)
    {
        cubeSide.CColor = colorPair;

        cubeSide._Mesh.material.color = colorPair.Color;
        if (applyColourblindness)
            cubeSide._Mesh.material.mainTexture = colorPair.Shape;
    }

    private void ApplyCubeColors(Cube cube)
    {
        ApplyColor(randomizedColors[0], cube.Top);
        ApplyColor(randomizedColors[1], cube.Front);
        ApplyColor(randomizedColors[2], cube.Right);
        ApplyColor(randomizedColors[3], cube.Bottom);
        ApplyColor(randomizedColors[4], cube.Back);
        ApplyColor(randomizedColors[5], cube.Left);
    }


    private void SetChoiceCubes()
    {
        CorrectCube = UnityEngine.Random.Range(0, foldedCubes.Length);
        int frontRightLeft = 0;

        ApplyCubeColors(foldedCubes[CorrectCube]);

        for (int i = 0; i < foldedCubes.Length; i++)
        {
            if (i == CorrectCube) continue;

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


    private void RandomizeColorList()
    {
        List<int> numbers = new List<int>() { 0,1,2,3,4,5 };

        for (int i = 0; i < 6; i++)
        {
            var rndNr = UnityEngine.Random.Range(0, numbers.Count);

            var t = sixColors[numbers[rndNr]];
            randomizedColors[i] = t;
            numbers.RemoveAt(rndNr);
        }
    }

}
