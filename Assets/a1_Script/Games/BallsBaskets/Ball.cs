using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BallType
{
    Orange,
    Onion,
    Football,
    Volleyball,
    Ball,
}

public class Ball : MonoBehaviour
{
    [field: SerializeField] public Rigidbody Rb { get; private set; }

    [field: SerializeField] public BallType BallType { get; private set; }
    [field: SerializeField] public bool SwitchBasket { get; private set; } = false;

    public void OnSpawn(Vector3 startPos)
    {
        this.transform.position = startPos;
        this.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f)));
        this.Rb.angularVelocity += new Vector3(Random.Range(-BallsBasketsGameSettings.AskFor.BallFallSpeed, BallsBasketsGameSettings.AskFor.BallFallSpeed),
                                               Random.Range(-BallsBasketsGameSettings.AskFor.BallFallSpeed, BallsBasketsGameSettings.AskFor.BallFallSpeed),
                                               Random.Range(-BallsBasketsGameSettings.AskFor.BallFallSpeed, BallsBasketsGameSettings.AskFor.BallFallSpeed));
        // fall speed is inverted for intution's sake in the inspector
        this.Rb.drag = 5f - BallsBasketsGameSettings.AskFor.BallFallSpeed;
    }

    public void ActivateBasketSwitch()
    {
        this.SwitchBasket = true;
    }

    public void JumpToOtherBasket(BasketID jumpFromBasket)
    {
        SwitchBasket = false;
        this.Rb.drag = 0.2f;
        this.Rb.velocity = Vector3.zero;
        // the random numbers are correct just dont mess with it
        Rb.AddForce(new Vector3(jumpFromBasket == BasketID.Left ? Random.Range(2.9f, 3.16f) : Random.Range(-3.02f, -3.16f), Random.Range(7f, 10f), 0f), ForceMode.VelocityChange);
    }

}
