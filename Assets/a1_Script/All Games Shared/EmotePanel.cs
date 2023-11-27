using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct EmoteSet
{
    public Sprite emote;
    public Translation_SO message;
}
public class EmotePanel : MonoBehaviour
{
    private static EmotePanel instance;
    public static EmotePanel AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private EmoteSet[] positive;
    [SerializeField] private EmoteSet[] negative;

    [SerializeField] private GameObject screen;
    [SerializeField] private Image emojiImage;
    [SerializeField] private TMP_Text message_Text;




    public void ShowCorrect()
    {
        screen.SetActive(true);
        var index = UnityEngine.Random.Range(0, positive.Length);
        message_Text.text = positive[index].message[GlobalVariables.AppLanguage];
        emojiImage.sprite = positive[index].emote;
    }

    
    public void ShowIncorrect()
    {
        screen.SetActive(true);
        var index = UnityEngine.Random.Range(0, negative.Length);
        message_Text.text = negative[index].message[GlobalVariables.AppLanguage];
        emojiImage.sprite = negative[index].emote;
    }






}
