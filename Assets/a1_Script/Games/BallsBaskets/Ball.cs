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
    [SerializeField] private Rigidbody rb;

    [field: SerializeField] public BallType BallType { get; private set; }

    public void OnSpawn(Vector3 startPos)
    {
        this.transform.position = startPos;
        this.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f)));
        this.rb.angularVelocity += new Vector3(Random.Range(-BallsBasketsGameSettings.AskFor.BallFallSpeed, BallsBasketsGameSettings.AskFor.BallFallSpeed),
                                               Random.Range(-BallsBasketsGameSettings.AskFor.BallFallSpeed, BallsBasketsGameSettings.AskFor.BallFallSpeed),
                                               Random.Range(-BallsBasketsGameSettings.AskFor.BallFallSpeed, BallsBasketsGameSettings.AskFor.BallFallSpeed));
        // fall speed is inverted for intution's sake in the inspector
        this.rb.drag = 5f - BallsBasketsGameSettings.AskFor.BallFallSpeed;
    }

}
