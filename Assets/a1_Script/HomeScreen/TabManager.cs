using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TabState {
    LoginScreen,
    MainMenu,
    GameSelection,
    Scoreboard,
    Settings,
    GameInfo,
}


public class TabManager : MonoBehaviour
{
    private static TabManager instance;
    public static TabManager AskFor {  get => instance; }

    private void Awake()
    {
        instance = this;
        SetTabState(CurrentTabState);
    }


    [field: SerializeField] public TabState CurrentTabState { get; private set; }
    [field: SerializeField] public List<Tab> Tabs { get; private set; }

    public void AddTab(Tab tab)
    {
        Tabs.Add(tab);
    }

    public void SetTabState(TabState state)
    {
        for (int i = 0; i < Tabs.Count; i++)
        {
            if (Tabs[i].TabState != state)
                Tabs[i].Hide();
            else
                Tabs[i].Show();
        }
    }

    public void SetTabStateFromInspector(string stateName)
    {
        for (int i = 0; i < Tabs.Count; i++)
        {
            if (Tabs[i].TabState.ToString() != stateName)
                Tabs[i].Hide();
            else
                Tabs[i].Show();
        }
    }

}
