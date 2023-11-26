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


    // Events

    [SerializeField] private GameObject startGameButton;
    [SerializeField] private UnityEvent OnStartGameClicked;

    public void StartGame()
    {
        OnStartGameClicked?.Invoke();
    }

    [SerializeField] private UnityEvent OnRestartGameClicked;

    public void RestartGame()
    {
        OnRestartGameClicked?.Invoke();
        startGameButton.SetActive(true);
    }

}
