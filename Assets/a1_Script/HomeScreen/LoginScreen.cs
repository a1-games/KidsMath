using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreenGameObject;

    private void Awake()
    {
        loadingScreenGameObject.SetActive(false);
        if (GlobalVariables.ClickedLogInScreenThisSession) return;
        loadingScreenGameObject.SetActive(true);
    }
}
