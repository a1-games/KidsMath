using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveOnAwake : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
}
