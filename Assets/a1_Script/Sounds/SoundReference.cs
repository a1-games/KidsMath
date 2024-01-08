
using UnityEngine;
using UnityEngine.UI;

public class SoundReference : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private SoundKey audioTrack;
    [Range(0f, 1f)]
    [SerializeField] private float volume = 1f;

    public void PlaySound()
    {
        AudioManager.AskFor.PlaySound(sound, audioTrack, volume);
    }

}
