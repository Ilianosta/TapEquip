using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndScreen : MonoBehaviour
{
    [SerializeField] private GameObject playerWinObj;
    [SerializeField] private GameObject playerLoseObj;
    internal void ShowPlayerWinner(bool playerWins)
    {
        playerWinObj.SetActive(playerWins);
        playerLoseObj.SetActive(!playerWins);
    }
}
