using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum BasketID
{
    Left,
    Right,
}

public class BallsBasketsController : GameManager
{
    private static BallsBasketsController instance;
    public static BallsBasketsController AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private BallSpawner ballSpawner;
    [SerializedDictionary]
    [SerializeField] private BallType selectedBallType;
    [SerializeField] private Translation_SO selectLeastBalls;
    [SerializeField] private Translation_SO selectMostBalls;
    [SerializeField] private SerializedDictionary<BallType, Translation_SO> currentBallType = new SerializedDictionary<BallType, Translation_SO>();
    public string CurrentBallType { get => currentBallType[selectedBallType][GlobalVariables.AppLanguage]; }


    [SerializeField] private Basket[] baskets;

    public Dictionary<BasketID, int> BallCounts { get; private set; } = new Dictionary<BasketID, int>()
    {
        { BasketID.Left, 0 },
        { BasketID.Right, 0 },
    };

    private bool canClickBaskets = false;


    public override void StartGame()
    {
        ballSpawner.ActivateSpawner();
    }

    public override void ResetGame()
    {
        BallCounts.Clear();
        BallCounts = new Dictionary<BasketID, int>() {
            { BasketID.Left, 0 },
            { BasketID.Right, 0 },
        };


        ballSpawner.ResetSpawner();
    }



    public void AddBallToBasket(BasketID basket)
    {
        BallCounts[basket]++;
        //print(" Left: " + BallCounts[BasketID.Left] + " Right: " + BallCounts[BasketID.Right]);
        CheckIfRoundOver();
    }


    public void CheckIfRoundOver()
    {
        if (ballSpawner.BallsToBeSpawned <= 0 &&
            BallCounts[BasketID.Left] + BallCounts[BasketID.Right] == ballSpawner.BallsThisRound)
        {
            OnRoundOver();
        }
    }

    [SerializeField] private GameObject roundOver_Panel;
    [SerializeField] private TMP_Text roundOver_Text;
    private bool selectGreatest = true;
    public void OnRoundOver()
    {
        roundOver_Text.text = selectMostBalls[GlobalVariables.AppLanguage] + " " + CurrentBallType;
        if (BallsBasketsGameSettings.AskFor.EnableSelectingLeastBalls)
        {
            // ~50% chance of having to select the smallest number
            if (Random.Range(0, 2) == 0)
            {
                selectGreatest = false;
                roundOver_Text.text = selectLeastBalls[GlobalVariables.AppLanguage] + " " + CurrentBallType;
            }
        }

        roundOver_Panel.SetActive(true);
        canClickBaskets = true;

        // outline the baskets
        for (int i = 0; i < baskets.Length; i++)
        {
            baskets[i].Outlined = true;
        }
    }


    public void BasketClicked(RaycastHit hit)
    {
        if (!canClickBaskets) return;
        if (!hit.transform.CompareTag("Basket")) return;
        var root = hit.transform.root.gameObject;
        var basketID = root.GetComponent<Basket>().BasketID;

        var biggestBasket = BallCounts[BasketID.Left] > BallCounts[BasketID.Right] ? BasketID.Left : BasketID.Right;

        roundOver_Panel.SetActive(false);
        canClickBaskets = false;


        // outline the baskets
        for (int i = 0; i < baskets.Length; i++)
        {
            baskets[i].Outlined = false;
        }

        if (basketID == biggestBasket && selectGreatest)
        {
            // we were correct about greatest
            CorrectAnswer();
            return;
        }
        if (basketID != biggestBasket && !selectGreatest)
        {
            // we were correct about smallest
            CorrectAnswer();
            return;
        }
        // else
        IncorrectAnswer();

    }



    protected override void CorrectAnswer()
    {
        EmotePanel.AskFor.ShowCorrect();
        GameSave.IncreaseSavedGameInt(MyGames.BallsInBaskets, BallsBasketsGameSettings.AskFor.Difficulty, true, 1);
    }


    protected override void IncorrectAnswer()
    {
        EmotePanel.AskFor.ShowIncorrect();
        GameSave.IncreaseSavedGameInt(MyGames.BallsInBaskets, BallsBasketsGameSettings.AskFor.Difficulty, false, 1);
    }


}
