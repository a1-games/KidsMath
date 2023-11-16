using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum BasketID
{
    Left,
    Right,
}

public class BallsBasketsController : MonoBehaviour
{
    private static BallsBasketsController instance;
    public static BallsBasketsController AskFor { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private BallType currentBallType;

    public Dictionary<BasketID, int> BallCounts { get; private set; } = new Dictionary<BasketID, int>()
    {
        { BasketID.Left, 0 },
        { BasketID.Right, 0 },
    };

    private bool canClickBaskets = false;

    public void AddBallToBasket(BasketID basket)
    {
        BallCounts[basket]++;

        print(" Left: " + BallCounts[BasketID.Left] + " Right: " + BallCounts[BasketID.Right]);

        CheckIfRoundOver();
    }

    public void StartGame()
    {
        ballSpawner.ActivateSpawner();
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
        if (GameSettings.AskFor.EnableSelectingLeastBalls)
        {
            // ~50% chance of having to select the smallest number
            if (Random.Range(0, 2) == 0)
                selectGreatest = false;
        }
        roundOver_Text.text = "Click on the basket with the " + (selectGreatest ? "greatest" : "least") + " amount of " + currentBallType + "s.";
        roundOver_Panel.SetActive(true);
        canClickBaskets = true;
    }


    public void BasketClicked(RaycastHit hit)
    {
        if (!canClickBaskets) return;
        if (!hit.transform.CompareTag("Basket")) return;
        var root = hit.transform.root.gameObject;
        var basketID = root.GetComponent<Basket>().BasketID;

        var biggestBasket = BallCounts[BasketID.Left] > BallCounts[BasketID.Right] ? BasketID.Left : BasketID.Right;

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

        canClickBaskets = false;
    }



    private void CorrectAnswer()
    {
        print("Answer was correct");
    }


    private void IncorrectAnswer()
    {
        print("Answer was incorrect");

    }


}
