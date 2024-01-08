
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class IngameInfo : MonoBehaviour
{
    [SerializeField] private GameInfo_SO gameInfo;

    [SerializeField] private TMP_Text gameTitle;
    [SerializeField] private TMP_Text gameDescription;

    [SerializeField] private Image gameThumbnail;

    private void Awake()
    {
        GlobalVariables.SelectedGameInfo = gameInfo;
        LoadCurrentGameInfo();
    }

    public void LoadCurrentGameInfo()
    {
        var info = GlobalVariables.SelectedGameInfo;

        if (info.GameThumbnail != null)
        {
            gameThumbnail.sprite = gameInfo.GameThumbnail;
            gameTitle.text = gameInfo.GameTitle[GlobalVariables.AppLanguage];
            gameDescription.text = gameInfo.GameDescription[GlobalVariables.AppLanguage];
        }
    }


}
