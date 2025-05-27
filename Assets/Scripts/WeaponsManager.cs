using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject swordTwo;
    [SerializeField] private GameObject swordThree;
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private GameObject shopObject;
    [SerializeField] private GameObject swordPriceText;
    [SerializeField] private GameObject gunPriceText;
    [SerializeField] private GameObject swordTwoPriceText;
    [SerializeField] private GameObject swordThreePriceText;

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
            swordTwo.SetActive(false);
            swordThree.SetActive(false);
            // gun.GetComponent<MeshRenderer>().enabled = true;
            // gun.GetComponent<SimpleLaserController>().enabled = true;
            // sword.GetComponent<MeshRenderer>().enabled = false;
            // sword.GetComponent<WeaponController>().enabled = false;
        }
        else if (!shopScript.playerBoughtGun && moneyScript.bankAccount >= 50)
        {
            shopScript.playerBoughtGun = true;
            shopScript.playerUsingGun = true;
            moneyScript.bankAccount -= 50;
            gun.SetActive(true);
            sword.SetActive(false);
            gunPriceText.SetActive(false);
            swordTwo.SetActive(false);
            swordThree.SetActive(false);
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
            swordTwo.SetActive(false);
            swordThree.SetActive(false);
        }
        else if (!shopScript.playerBoughtSword && moneyScript.bankAccount >= 0)
        {
            shopScript.playerBoughtSword = true;
            shopScript.playerUsingSword = true;
            sword.SetActive(true);
            gun.SetActive(false);
            swordTwo.SetActive(false);
            swordThree.SetActive(false);
            swordPriceText.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money to buy the sword.");
        }
    }

    public void SwordTwoEnable()
    {
        if (shopScript.playerBoughtSwordTwo)
        {
            shopScript.playerBoughtSwordTwo = true;
            shopScript.playerUsingSwordTwo = true;
            swordTwo.SetActive(true);
            sword.SetActive(false);
            gun.SetActive(false);
            swordThree.SetActive(false);
        }
        else if (!shopScript.playerBoughtSwordTwo && moneyScript.bankAccount >= 100)
        {
            shopScript.playerBoughtSwordTwo = true;
            shopScript.playerUsingSwordTwo = true;
            moneyScript.bankAccount -= 100;
            swordTwoPriceText.SetActive(false);
            swordTwo.SetActive(true);
            sword.SetActive(false);
            gun.SetActive(false);
            swordThree.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money to buy the second sword.");
        }
    }
    
    public void SwordThreeEnable()
    {
        if (shopScript.playerBoughtSwordThree)
        {
            shopScript.playerBoughtSwordThree = true;
            shopScript.playerUsingSwordThree = true;
            swordThree.SetActive(true);
            sword.SetActive(false);
            gun.SetActive(false);
            swordTwo.SetActive(false);
        }
        else if (!shopScript.playerBoughtSwordThree && moneyScript.bankAccount >= 200)
        {
            shopScript.playerBoughtSwordThree = true;
            shopScript.playerUsingSwordThree = true;
            moneyScript.bankAccount -= 200;
            swordThreePriceText.SetActive(false);
            swordThree.SetActive(true);
            sword.SetActive(false);
            gun.SetActive(false);
            swordTwo.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money to buy the third sword.");
        }
    }

}
