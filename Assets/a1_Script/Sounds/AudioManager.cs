using AYellowpaper.SerializedCollections;
using UnityEngine;



public enum SoundKey
{
    UIclicks,
    GAMEsounds,
    BACKGROUND,
}


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager AskFor { get => instance; }
    private void Awake()
    {
        instance = this;
    }

    public float Volume { get; private set; } = 0.5f;
    
    public void SetVolume(float volume)
    {
        var vol = Mathf.Clamp01(volume);
        Volume = vol;
    }

    [field: SerializeField]
    public SerializedDictionary<SoundKey, AudioSource> AudioSources { get; private set; }

    public void PlaySound(AudioClip clip, SoundKey track)
    {
        var _as = AudioSources[track];
        _as.clip = clip;
        _as.volume = Volume;
        _as.Play();
    }

    [field: SerializeField]
    public UiSounds UiSounds { get; private set; }

}
