using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslatedMessage", menuName = "ScriptableObjects/AllGames/TranslatedMessage", order = 1)]
public class Translation_SO : ScriptableObject
{
    [SerializeField] [SerializedDictionary]
    private SerializedDictionary<SupportedLanguages, string> TranslatedMessages = new SerializedDictionary<SupportedLanguages, string>()
    {
        { SupportedLanguages.Danish, "" },
        { SupportedLanguages.English, "" },
    };

    public string this[SupportedLanguages lang]
    {
        get { return TranslatedMessages[lang]; }
    }
}
