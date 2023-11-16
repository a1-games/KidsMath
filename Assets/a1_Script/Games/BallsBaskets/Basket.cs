using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [field: SerializeField] public BasketID BasketID { get; private set; }

    public void OnBallEnteredBasket(Collider other)
    {
        BallsBasketsController.AskFor.AddBallToBasket(BasketID);
        Destroy(other.gameObject);
    }

}
