using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private int ballsToBeSpawned = 3;
    public int BallsToBeSpawned { get => ballsToBeSpawned; }
    public int BallsThisRound { get; private set; }

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
        var zeroOrOne = Random.Range(0, 2);

        var newBall = Instantiate(ballPrefab);
        newBall.transform.position = spawnPoints[zeroOrOne].position;

        var ballScript = newBall.GetComponent<Ball>();
        ballScript.OnSpawn();

        // note that one ball was spawned
        ballsToBeSpawned--;
    }
}
