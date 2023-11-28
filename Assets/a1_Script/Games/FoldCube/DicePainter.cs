using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public struct ColourblindColor
{
    public Color Color;
    public Texture2D Shape;
}



[Serializable]
public struct CubeSides
{
    public MeshRenderer Top;
    public MeshRenderer Bottom;
    public MeshRenderer Right;
    public MeshRenderer Left;
    public MeshRenderer Front;
    public MeshRenderer Back;
}




public class DicePainter : MonoBehaviour
{

    [SerializeField] private bool applyColourblindness;

    [SerializeField]
    private ColourblindColor[] sixColors = new ColourblindColor[6];

    [SerializeField] private CubeSides foldoutCube;

    [SerializeField] private CubeSides[] foldedCubes = new CubeSides[4];


    private ColourblindColor[] randomizedColors = new ColourblindColor[6];

    private void Start()
    {
        RandomizeColorList();
        ApplyCubeColors(foldoutCube);
        SetChoiceCubes();
    }

    private void ApplyColor(ColourblindColor colorPair, MeshRenderer rend)
    {
        rend.material.color = colorPair.Color;
        if (applyColourblindness)
            rend.material.mainTexture = colorPair.Shape;
    }

    private void ApplyCubeColors(CubeSides cube)
    {
        ApplyColor(randomizedColors[0], cube.Top);
        ApplyColor(randomizedColors[1], cube.Bottom);
        ApplyColor(randomizedColors[2], cube.Right);
        ApplyColor(randomizedColors[3], cube.Left);
        ApplyColor(randomizedColors[4], cube.Front);
        ApplyColor(randomizedColors[5], cube.Back);
    }

    private void SetChoiceCubes()
    {
        int correctCube = UnityEngine.Random.Range(0, foldedCubes.Length);

        ApplyCubeColors(foldedCubes[correctCube]);

        for (int i = 0; i < foldedCubes.Length; i++)
        {
            if (i == correctCube) continue;

            // switch two colours around so they aren't exactly the same as the correct cube
            int indexToSwitch = UnityEngine.Random.Range(0, 5);
            var tmpColor = randomizedColors[indexToSwitch];
            randomizedColors[indexToSwitch] = randomizedColors[indexToSwitch+1];
            randomizedColors[indexToSwitch+1] = tmpColor;

            ApplyColor(randomizedColors[0], foldedCubes[i].Top);
            ApplyColor(randomizedColors[1], foldedCubes[i].Bottom);
            ApplyColor(randomizedColors[2], foldedCubes[i].Right);
            ApplyColor(randomizedColors[3], foldedCubes[i].Left);
            ApplyColor(randomizedColors[4], foldedCubes[i].Front);
            ApplyColor(randomizedColors[5], foldedCubes[i].Back);
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
