
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class IngameInfo : MonoBehaviour
{

    [SerializeField] private TMP_Text gameTitle;
    [SerializeField] private TMP_Text gameDescription;

    [SerializeField] private Image gameThumbnail;

    private void Start()
    {
        LoadCurrentGameInfo();
    }

    private void LoadCurrentGameInfo()
    {
        var info = GlobalVariables.SelectedGameInfo;

        if (info.Thumbnail != null)
        {
            gameThumbnail.sprite = info.Thumbnail;
            gameTitle.text = info.Title;
            gameDescription.text = info.Description;
        }
    }



}
