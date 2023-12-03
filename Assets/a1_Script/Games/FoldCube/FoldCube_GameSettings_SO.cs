
using UnityEngine;


[CreateAssetMenu(fileName = "Difficulty_0", menuName = "ScriptableObjects/GameSettings/FoldCube", order = 1)]
public class FoldCube_GameSettings_SO : ScriptableObject
{

    [field: SerializeField] public bool ApplyColourblindness { get; private set; }

    [field: SerializeField] public ColourblindColor[] SixColors { get; private set; } = new ColourblindColor[6];

}
