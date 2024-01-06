using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject mainMenuObj;
    [SerializeField] private GameObject inGameObj;
    [SerializeField] private UIEndScreen endScreen;
    private void Awake()
    {
        if (UIManager.instance) Destroy(this);
        else UIManager.instance = this;
    }

    internal void ShowMainMenu(bool show)
    {
        mainMenuObj.SetActive(show);
    }

    internal void ShowInGameUI(bool show)
    {
        inGameObj.SetActive(show);
    }

    internal void ShowEndUI(bool show)
    {
        endScreen.gameObject.SetActive(show);
        endScreen.ShowPlayerWinner(GameManager.instance.playerWins);
    }
}
