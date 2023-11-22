using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SharedGameManager : MonoBehaviour
{
    private static SharedGameManager instance;
    public static SharedGameManager AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameSettings gameSettings;

    // Events

    [SerializeField] private UnityEvent OnStartGameClicked;

    public void StartGame()
    {
        OnStartGameClicked?.Invoke();
    }

    [SerializeField] private UnityEvent OnRestartGameClicked;

    public void RestartGame()
    {
        OnRestartGameClicked?.Invoke();
    }

}
