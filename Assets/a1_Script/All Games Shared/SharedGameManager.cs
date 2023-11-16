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

    [SerializeField] private UnityEvent OnStartGameClicked;

    public void StartGame()
    {
        OnStartGameClicked?.Invoke();
    }
}
