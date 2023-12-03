using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManager : MonoBehaviour
{
    public abstract void StartGame();
    public abstract void ResetGame();
    protected abstract void CorrectAnswer();
    protected abstract void IncorrectAnswer();
}
