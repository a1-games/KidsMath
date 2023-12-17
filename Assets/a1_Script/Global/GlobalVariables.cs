
using System.Collections.Generic;

public static class GlobalVariables
{

    public static bool ClickedLogInScreenThisSession { get; set; } = false;

    public static SupportedLanguages AppLanguage { get; set; } = SupportedLanguages.English;


    public static Dictionary<MyGames, string> GameIDs { get; private set; } = new Dictionary<MyGames, string>()
    {
        { MyGames.BallsInBaskets, "BallsBaskets" },
        { MyGames.FoldCube, "FoldCube" },

    };

}
