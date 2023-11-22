
using System;
using UnityEngine;

public abstract class GameSettings : MonoBehaviour
{

    protected virtual void Awake()
    {
        CopySettingsFromSO();
    }

    protected abstract void CopySettingsFromSO();

    public abstract void SetDifficultySO(ScriptableObject GameSettings_SO);
}
