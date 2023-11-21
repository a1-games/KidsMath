using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [field: SerializeField] public BasketID BasketID { get; private set; }
    [SerializeField] private Outline outline;

    private bool outlined = false;
    public bool Outlined
    {
        get
        {
            return outlined;
        }
        set
        {
            outlined = value;
            if (outlined)
                outline.Enable();
            else
                outline.Disable();
        }
    }


    public void OnBallEnteredBasket(Collider other)
    {
        BallsBasketsController.AskFor.AddBallToBasket(BasketID);
        Destroy(other.gameObject);
    }

}
