
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Difficulty_0", menuName = "ScriptableObjects/AllGames/GameInfo", order = 1)]
public class GameInfo_SO : ScriptableObject
{


    [field: SerializeField] public Translation_SO GameTitle { get; private set; }
    [field: SerializeField] public Translation_SO GameDescription { get; private set; }

    [field: SerializeField] public MyGames Game { get; private set; }
    [field: SerializeField] public Sprite GameThumbnail { get; private set; }



}
