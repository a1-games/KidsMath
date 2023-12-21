using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] private GameObject loginScreenPanel;

    private void Awake()
    {
        loginScreenPanel.SetActive(false);
        if (GlobalVariables.ClickedLogInScreenThisSession) return;
        loginScreenPanel.SetActive(true);
    }
}
