
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private SoundKey audioTrack;


    private void Awake()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.AskFor.PlaySound(sound, audioTrack);
        });
    }

}
