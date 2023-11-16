using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static GameSettings instance;
    public static GameSettings AskFor { get => instance; }

    [SerializeField] private GameSettings_ScriptableObject _gameSettings_SO;


    // Should the player be able to guess least and greatest or only greats amount of balls?
    private bool enableSelectingLeastBalls;
    public bool EnableSelectingLeastBalls { get => enableSelectingLeastBalls; }

    // Should balls sometimes change baskets?
    private bool enableBasketChange;
    public bool EnableBasketChange { get => enableBasketChange; }

    // Should skyfall mode be enabled?
    private bool enableSkyfall;
    public bool EnableSkyfall { get => enableSkyfall; }

    // Ball Amount Per Round
    private int minBallCount;
    private int maxBallCount;
    public int MinBallCount { get => minBallCount; }
    public int MaxBallCount { get => maxBallCount; }

    // Spawn Times
    private float minTimeBetweenSpawns;
    private float maxTimeBetweenSpawns;
    public float MinTimeBetweenSpawns { get => minTimeBetweenSpawns; }
    public float MaxTimeBetweenSpawns { get => maxTimeBetweenSpawns; }

    // Fall Speed
    private float ballFallSpeed = 0.5f;
    public float BallFallSpeed { get => ballFallSpeed; }


    private void Awake()
    {
        instance = this;
        CopySettingsFromSO();
    }

    private void CopySettingsFromSO()
    {
        this.enableSelectingLeastBalls = _gameSettings_SO.EnableSelectingLeastBalls;
        this.enableBasketChange = _gameSettings_SO.EnableBasketChange;
        this.enableSkyfall = _gameSettings_SO.EnableSkyfall;

        this.minBallCount = _gameSettings_SO.MinBallCount;
        this.maxBallCount = _gameSettings_SO.MaxBallCount;

        this.minTimeBetweenSpawns = _gameSettings_SO.MinTimeBetweenSpawns;
        this.maxTimeBetweenSpawns = _gameSettings_SO.MaxTimeBetweenSpawns;

        this.ballFallSpeed = _gameSettings_SO.BallFallSpeed;
    }




}
