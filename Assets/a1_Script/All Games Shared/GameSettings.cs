
using System;
using UnityEngine;

public abstract class GameSettings : MonoBehaviour
{
    public int Difficulty { get; private set; }
    protected abstract void CopySettingsFromSO();

    public virtual void SetDifficultySO(ScriptableObject GameSettings_SO, int difficulty)
    {
        Difficulty = difficulty;
        CopySettingsFromSO();
    }
}
