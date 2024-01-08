using AYellowpaper.SerializedCollections;
using UnityEngine;




public enum UiSoundKey
{
    Click,
    Open,
    Close,
}

public class UiSounds : MonoBehaviour
{
    [field: SerializeField]
    public SerializedDictionary<UiSoundKey, AudioClip> UiSoundClips { get; private set; }

    public AudioClip this[UiSoundKey sKey]
    {
        get
        {
            return UiSoundClips[sKey];
        }
    }
}





