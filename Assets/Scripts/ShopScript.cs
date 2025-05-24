using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private Group79Game input;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private Button swordOneShopButton;
    [SerializeField] private Button gunOneShopButton;
    [SerializeField] private Button healthPackShopButton;
    [SerializeField] private Button TBCShopButton;
    [SerializeField] private bool playerInShop = false;
    [SerializeField] private AudioClip shopSound;
    [SerializeField] private AudioClip buttonSound;

    public bool playerUsingSword = false;
    public bool playerUsingGun = false;
    public bool playerBoughtSword = false;
    public bool playerBoughtGun = false;
    

    public bool shopOpen = false;

    public TMP_Text coinNumText;
    private Money moneyScript;

    void Awake()
    {
        input = new Group79Game();
        input.GameUI.Shop.performed += ShopManagement;
        moneyScript = moneyObject.GetComponent<Money>();
    }
    void OnEnable()
    {
        input.GameUI.Enable();
    }
    void OnDisable()
    {
        input.GameUI.Disable();
    }
    public void OpenShop()
    {
        Time.timeScale = 0f;
        Enable();
    }
    public void CloseShop()
    {
        Time.timeScale = 1f;
        Disable();
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void BuySword()
    {
        if (moneyScript.bankAccount >= 20)
        {
            AudioSource.PlayClipAtPoint(buttonSound, transform.position, 1f);
            moneyScript.bankAccount -= 20;
            playerBoughtSword = true;
            playerUsingSword = true;
            Debug.Log("Bought Sword");
        }
        else
        {
            Debug.Log("Not enough money for sword");
        }
    }
    public void ShopManagement(InputAction.CallbackContext context)
    {
        if (!playerInShop)
        {
            Debug.Log("Player not in shop");
            return;
        }

        if (shopOpen == false)
        {
            shopOpen = true;
            OpenShop();
        }
        else
        {
            shopOpen = false;
            CloseShop();
        }
    }
    // Detecting when the player has entered the shop
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(shopSound, transform.position, 1f);
            playerInShop = true;
            Debug.Log("Player in shop");
        }
    }
    // Detecting when the player leaves the shop
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(shopSound, transform.position, 1f);
            playerInShop = true;
            playerInShop = false;
            Debug.Log("Player left shop");
        }
    }
    void Update() {
        // Update the coin number text in the shop
        coinNumText.text = moneyScript.bankAccount.ToString();

        if (playerBoughtSword) {
            swordOneShopButton.interactable = true;
        }
        else if (!playerBoughtSword && (moneyScript.bankAccount >= 20)) {
            swordOneShopButton.interactable = true;
        }
        else {
            swordOneShopButton.interactable = false;
        }

        if (playerBoughtGun) {
            gunOneShopButton.interactable = true;
        }
        else if (!playerBoughtGun && (moneyScript.bankAccount >= 50)) {
            gunOneShopButton.interactable = true;
        }
        else {
            gunOneShopButton.interactable = false;
        }

        // if ((moneyScript.bankAccount < 20) && !playerBoughtSword)
        // {
        //     swordOneShopButton.interactable = false
        // }
        // else
        // {
        //     swordOneShopButton.interactable = true;
        // }

        // if ((moneyScript.bankAccount < 50) && !playerBoughtGun)
        // {
        //     gunOneShopButton.interactable = false;
        // }
        // else
        // {
        //     gunOneShopButton.interactable = true;
        // }

        if (moneyScript.bankAccount >= 10) {
            healthPackShopButton.interactable = true;
        }
        else {
            healthPackShopButton.interactable = false;
        }

        TBCShopButton.interactable = false;
    }


}
