
using UnityEngine;
using UnityEngine.UI;

public class SoundReference : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private SoundKey audioTrack;

    public void PlaySound()
    {
        AudioManager.AskFor.PlaySound(sound, audioTrack);
    }

}
