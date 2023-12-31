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

    public void ResetSpawner()
    {
        spawnerIsActive = false;
        BallsThisRound = GetNewBallCount();
        ballsToBeSpawned = BallsThisRound;
        SpawnedBallCounts = new Dictionary<BasketID, int>() {
        { BasketID.Left, 0 },
        { BasketID.Right, 0 },
        };
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
        return Random.Range(BallsBasketsGameSettings.AskFor.MinTimeBetweenSpawns, BallsBasketsGameSettings.AskFor.MaxTimeBetweenSpawns);
    }

    private int GetNewBallCount()
    {
        return Random.Range(BallsBasketsGameSettings.AskFor.MinBallCount, BallsBasketsGameSettings.AskFor.MaxBallCount + 1);
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

            // if the last ball is a tiebreaker, ALWAYS break the tie. NEVER end in a tie!
            if (SpawnedBallCounts[smallestBasket] + 1 == SpawnedBallCounts[biggestBasket])
            {
                selectedBasket = biggestBasket;
            }
        }

        // spawn ball
        var ballScript = Instantiate(ballPrefab).GetComponent<Ball>();
        ballScript.OnSpawn(spawnPoints[selectedBasket].position);

        // should the ball change basket?
        if (BallsBasketsGameSettings.AskFor.ChanceOfBasketChange > 0f)
        {
            var result = Random.Range(0f, 1f);

            // if we rolled within the chance, make the ball switch
            if (result <= BallsBasketsGameSettings.AskFor.ChanceOfBasketChange)
            {
                ballScript.ActivateBasketSwitch();
                // invert the selected basket
                selectedBasket = selectedBasket == BasketID.Left ? BasketID.Right : BasketID.Left;
            }
        }

        SpawnedBallCounts[selectedBasket]++;

        // keep track
        ballsToBeSpawned--;
    }
}
