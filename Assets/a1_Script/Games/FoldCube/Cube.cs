using System;
using UnityEngine;



[Serializable]
public class CubeSide
{
    public ColourblindColor CColor;
    public MeshRenderer _Mesh;
}



public class Cube : MonoBehaviour
{
    public CubeSide Front;
    public CubeSide Back;
    public CubeSide Right;
    public CubeSide Left;
    public CubeSide Top;
    public CubeSide Bottom;
}
