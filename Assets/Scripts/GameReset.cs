using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private GameObject shopObject;
    [SerializeField] private Interactions interactions;
    [SerializeField] private ShopScript shopScript;
    private Money moneyScript;

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
        shopScript = shopObject.GetComponent<ShopScript>();
        GameReseting();
    }

    void GameReseting()
    {
        moneyScript.bankAccount = 0;
        shopScript.playerBoughtGun = false;
        shopScript.playerBoughtSword = false;
        shopScript.playerBoughtSwordTwo = false;
        shopScript.playerBoughtSwordThree = false;
    }
}
