
using UnityEngine;


[CreateAssetMenu(fileName = "Difficulty_0", menuName = "ScriptableObjects/BallsBuckets/GameSettings", order = 1)]
public class BallsBaskets_GameSettings_SO : ScriptableObject
{
    [Header("You have to selected the lowest number sometimes:")]
    // Should balls sometimes change baskets?
    [SerializeField] private bool enableSelectingLeastBalls = false;

    [Header("Ball Sometimes Switch Basket:")]
    // Should balls sometimes change baskets?
    [Range(0f, 1f)]
    [SerializeField] private float chanceOfBasketChange = 0f;

    [Header("Sometimes Multiple Balls Drop At Once:")]
    // Should skyfall mode be enabled?
    [SerializeField] private bool enableSkyfall = false;

    // Ball Amount
    [Header("How Many Balls Should Be Spawned Per Round?")]
    [Range(1, 50)]
    [SerializeField] private int minBallCount = 2;
    [Range(1, 50)]
    [SerializeField] private int maxBallCount = 8;

    // Spawn Times
    [Header("How Much Time In Between Each Spawn?")]
    [Range(0.01f, 3f)]
    [SerializeField] private float minTimeBetweenSpawns = 0.5f;
    [Range(0.5f, 5f)]
    [SerializeField] private float maxTimeBetweenSpawns = 2f;

    // Spawn Times
    [Header("How Fast Should The Balls Fall?")]
    [Range(1f, 5f)]
    [SerializeField] private float ballFallSpeed = 1f;


    // Public Properties
    public bool EnableSelectingLeastBalls { get => enableSelectingLeastBalls; }
    public float ChanceOfBasketChange { get => chanceOfBasketChange; }
    public bool EnableSkyfall { get => enableSkyfall; }

    public int MinBallCount { get => minBallCount; }
    public int MaxBallCount { get => maxBallCount; }

    public float MinTimeBetweenSpawns { get => minTimeBetweenSpawns; }
    public float MaxTimeBetweenSpawns { get => maxTimeBetweenSpawns; }

    public float BallFallSpeed { get => ballFallSpeed; }
}
