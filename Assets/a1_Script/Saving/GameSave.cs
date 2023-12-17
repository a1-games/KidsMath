using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{



    public static void IncreaseSavedGameInt(MyGames gameKey, int difficulty, bool gameWon, int increment = 1)
    {
        var key = $"{GlobalVariables.GameIDs[gameKey]}_D{difficulty}_WIN";
        if (!gameWon)
            key = $"{GlobalVariables.GameIDs[gameKey]}_D{difficulty}_LOSE";

        int nr = PlayerPrefs.GetInt(key, 0);

        PlayerPrefs.SetInt(key, nr + increment);
        PlayerPrefs.Save();
    }
    

    public static int GetSavedGameInt(MyGames gameKey, int difficulty, bool gameWon)
    {
        var key = $"{GlobalVariables.GameIDs[gameKey]}_D{difficulty}_WIN";
        if (!gameWon)
            key = $"{GlobalVariables.GameIDs[gameKey]}_D{difficulty}_LOSE";

        int nr = PlayerPrefs.GetInt(key, 0);

        return nr;
    }






    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key, 0);
    }

    
    public static void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    /// <returns>"" if not found.</returns>
    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key, "");
    }




}
