using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private GameObject shopObject;
    [SerializeField] private GameObject swordPriceText;
    [SerializeField] private GameObject gunPriceText;
    private Money moneyScript;
    private ShopScript shopScript;

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
        shopScript = shopObject.GetComponent<ShopScript>();
    }

    void Update()
    {
        
    }

    public void GunEnable()
    {
        if (shopScript.playerBoughtGun)
        {
            shopScript.playerUsingGun = true;
            shopScript.playerUsingSword = false;
            gun.SetActive(true);
            sword.SetActive(false);
        }
        else if (!shopScript.playerBoughtGun && moneyScript.bankAccount >= 50)
        {
            shopScript.playerBoughtGun = true;
            shopScript.playerUsingGun = true;
            moneyScript.bankAccount -= 50;
            gun.SetActive(true);
            sword.SetActive(false);
            gunPriceText.SetActive(false);

        }
        else
        {
            Debug.Log("Not enough money to buy the gun.");
        }
    }

    public void SwordEnable()
    {
        if (shopScript.playerBoughtSword)
        {
            shopScript.playerUsingSword = true;
            shopScript.playerUsingGun = false;
            sword.SetActive(true);
            gun.SetActive(false);
        }
        else if (!shopScript.playerBoughtSword && moneyScript.bankAccount >= 20)
        {
            shopScript.playerBoughtSword = true;
            shopScript.playerUsingSword = true;
            moneyScript.bankAccount -= 20;
            sword.SetActive(true);
            gun.SetActive(false);
            swordPriceText.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money to buy the sword.");
        }
    }

}
