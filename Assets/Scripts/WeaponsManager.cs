using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    // This script manages the player's weapons, allowing them to switch between a gun and various swords

    // References to the weapon GameObjects
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject swordTwo;
    [SerializeField] private GameObject swordThree;

    [SerializeField] private GameObject moneyObject; // Reference to the Money script for managing player's bank account
    [SerializeField] private GameObject shopObject; // Reference to the ShopScript for managing shop purchases

    // UI textboxes for displaying prices
    [SerializeField] private GameObject swordPriceText;
    [SerializeField] private GameObject gunPriceText;
    [SerializeField] private GameObject swordTwoPriceText;
    [SerializeField] private GameObject swordThreePriceText;

    private Money moneyScript; // Reference to the Money script to manage the player's bank account
    private ShopScript shopScript; // Reference to the ShopScript to manage shop purchases

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>(); 
        shopScript = shopObject.GetComponent<ShopScript>();
    }

    public void GunEnable() // This method enables the Gun for the Player when they click the Gun button in the shop
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
        else if (!shopScript.playerBoughtGun && moneyScript.bankAccount >= 80)
        {
            shopScript.playerBoughtGun = true;
            shopScript.playerUsingGun = true;
            moneyScript.bankAccount -= 80;
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

    public void SwordEnable() // This method enables the Sword for the Player when they click the Sword button in the shop
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

    public void SwordTwoEnable() // This method enables the second sword for the player when they click the Gold Sword button in the shop
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
        else if (!shopScript.playerBoughtSwordTwo && moneyScript.bankAccount >= 15)
        {
            shopScript.playerBoughtSwordTwo = true;
            shopScript.playerUsingSwordTwo = true;
            moneyScript.bankAccount -= 15;
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
    
    public void SwordThreeEnable() // This method enables the third sword for the player when they click the Black Sword button in the shop
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
        else if (!shopScript.playerBoughtSwordThree && moneyScript.bankAccount >= 40)
        {
            shopScript.playerBoughtSwordThree = true;
            shopScript.playerUsingSwordThree = true;
            moneyScript.bankAccount -= 40;
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
