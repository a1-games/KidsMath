using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveOnAwake : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    private void Awake()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }
}
