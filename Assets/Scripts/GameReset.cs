using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    [SerializeField] private GameObject moneyObject;
    private Money moneyScript;
    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
        GameReseting();
    }

    void GameReseting()
    {
        moneyScript.bankAccount = 0;
    }
}
