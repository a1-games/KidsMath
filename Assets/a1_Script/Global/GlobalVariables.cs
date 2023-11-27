
using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public static bool ClickedLogInScreenThisSession { get; set; } = false;

    public static SupportedLanguages AppLanguage { get; set; } = SupportedLanguages.English;


    public static Dictionary<MyGames, string> GameIDs { get; private set; } = new Dictionary<MyGames, string>()
    {
        { MyGames.BallsInBaskets, "BallsBaskets" },

    };

}
