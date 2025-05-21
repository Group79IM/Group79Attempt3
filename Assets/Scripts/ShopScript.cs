using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private Group79Game input;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private bool shopOpen = false;
    [SerializeField] private bool playerInShop = false;
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
            playerInShop = true;
            Debug.Log("Player in shop");
        }
    }
    // Detecting when the player leaves the shop
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInShop = false;
            Debug.Log("Player left shop");
        }
    }
    void Update()
    {
        // Update the coin number text in the shop
        coinNumText.text = moneyScript.bankAccount.ToString();
        // Debug.Log("Money: " + moneyScript.bankAccount);
    }
}
