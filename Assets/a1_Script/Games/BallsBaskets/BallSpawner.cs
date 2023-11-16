using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    [field: SerializeField]
    [SerializedDictionary] private SerializedDictionary<BasketID, Transform> spawnPoints = new SerializedDictionary<BasketID, Transform>();

    private int ballsToBeSpawned = 3;
    public int BallsToBeSpawned { get => ballsToBeSpawned; }
    public int BallsThisRound { get; private set; }

    private Dictionary<BasketID, int> SpawnedBallCounts { get; set; } = new Dictionary<BasketID, int>()
    {
        { BasketID.Left, 0 },
        { BasketID.Right, 0 },
    };


    private float currentCooldown = 0f;
    private float timer = 0f;

    private bool spawnerIsActive = false;

    public void ActivateSpawner()
    {
        spawnerIsActive = true;
    }

    private void Start()
    {
        BallsThisRound = GetNewBallCount();
        ballsToBeSpawned = BallsThisRound;
    }

    private void FixedUpdate()
    {
        if (!spawnerIsActive) return;
        BallSpawning();
    }

    private void BallSpawning()
    {
        if (ballsToBeSpawned <= 0)
        {
            spawnerIsActive = false;
            return;
        }

        timer += Time.fixedDeltaTime;

        if (timer >= currentCooldown )
        {
            timer = 0f;

            SpawnOneBall();
            currentCooldown = GetNextCooldown();
        }
    }


    private float GetNextCooldown()
    {
        return Random.Range(GameSettings.AskFor.MinTimeBetweenSpawns, GameSettings.AskFor.MaxTimeBetweenSpawns);
    }

    private int GetNewBallCount()
    {
        return Random.Range(GameSettings.AskFor.MinBallCount, GameSettings.AskFor.MaxBallCount + 1);
    }

    private void SpawnOneBall()
    {
        var selectedBasket = Random.Range(0, 2) == 0 ? BasketID.Left : BasketID.Right;

        // make sure the last ball is not a tiebreaker
        if (ballsToBeSpawned == 1 &&
            // skip if the total count is uneven ( no possibility of a tie )
            SpawnedBallCounts[BasketID.Left] != SpawnedBallCounts[BasketID.Right]
            )
        {
            var biggestBasket = BasketID.Left;
            var smallestBasket = BasketID.Right;
            // flip it if the above isnt true
            if (SpawnedBallCounts[BasketID.Left] < SpawnedBallCounts[BasketID.Right])
            {
                biggestBasket = BasketID.Right;
                smallestBasket = BasketID.Left;
            }
            print("big: " + SpawnedBallCounts[biggestBasket] + " small: " + SpawnedBallCounts[smallestBasket]);


            // if the last ball is a tiebreaker, ALWAYS break the tie. NEVER end in a tie!
            if (SpawnedBallCounts[smallestBasket] + 1 == SpawnedBallCounts[biggestBasket])
            {
                selectedBasket = biggestBasket;
            }
        }

        // spawn ball
        var ballScript = Instantiate(ballPrefab).GetComponent<Ball>();
        ballScript.OnSpawn(spawnPoints[selectedBasket].position);
        SpawnedBallCounts[selectedBasket]++;

        // keep track
        ballsToBeSpawned--;
    }
}
