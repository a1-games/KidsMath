
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClick : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.AskFor.PlaySound(AudioManager.AskFor.UiSounds[UiSoundKey.Click], SoundKey.UIclicks);
        });
    }
}
