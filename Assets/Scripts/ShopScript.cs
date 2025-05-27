using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopScript : MonoBehaviour
{
    // This script manages the shop functionality, allowing players to buy weapons, manages the shop UI and determins when the player can interact with the shop

    [SerializeField] private Group79Game input; 
    [SerializeField] private GameObject gameObject; // Reference to the shop UI GameObject
    [SerializeField] private GameObject moneyObject; // Reference to the Money object to get the money script


    // References to the shop buttons for each weapon
    [SerializeField] private Button swordOneShopButton;
    [SerializeField] private Button gunOneShopButton;
    [SerializeField] private Button swordTwoShopButton;
    [SerializeField] private Button swordThreeShopButton;

    // Audio clips for shop sounds
    [SerializeField] private AudioClip shopSound;
    [SerializeField] private AudioClip buttonSound;

    // Player's weapon states
    public bool playerUsingSword = false;
    public bool playerUsingGun = false;
    public bool playerUsingSwordTwo = false;
    public bool playerUsingSwordThree = false;
    public bool playerBoughtSword = false;
    public bool playerBoughtGun = false;
    public bool playerBoughtSwordTwo = false;
    public bool playerBoughtSwordThree = false;
    

    [SerializeField] private bool playerInShop = false;
    public bool shopOpen = false;

    // Text components to display the number of coins
    public TMP_Text coinNumText;
    public TMP_Text coinNumTextShop;

    private Money moneyScript; // Reference to the Money script to manage the player's bank account

    void Awake()
    {
        input = new Group79Game(); // Creates a new instance of the input system
        input.GameUI.Shop.performed += ShopManagement; // Runs the ShopManagement method when 'e' is pressed
        moneyScript = moneyObject.GetComponent<Money>(); // Get the Money script component to manage the player's bank account
    }
    void OnEnable()
    {
        input.GameUI.Enable();
        
    }
    void OnDisable()
    {
        input.GameUI.Disable();
        
    }
    public void OpenShop() // Opens the shop UI and pauses the game
    {
        Time.timeScale = 0f;
        Enable();
        Debug.Log("open shop");
        AudioSource.PlayClipAtPoint(shopSound, transform.position, 1f);
    }
    public void CloseShop() // Closes the shop UI and resumes the game
    {
        Time.timeScale = 1f;
        Disable();
        Debug.Log("close shop");
        AudioSource.PlayClipAtPoint(shopSound, transform.position, 1f);
    }
    public void Disable() // Disables the shop UI GameObject
    {
        gameObject.SetActive(false);
    }
    public void Enable() // Enables the shop UI GameObject
    {
        gameObject.SetActive(true);
    }
    public void ShopManagement(InputAction.CallbackContext context) 
    {
        if (!playerInShop) // Checks if the player is in the shop before allowing them to open or close it
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
            playerInShop = true;
            playerInShop = false;
            Debug.Log("Player left shop");
        }
    }
    void Update()
    {
        // Update the coin number text in the shop and on screen
        coinNumText.text = moneyScript.bankAccount.ToString();
        coinNumTextShop.text = moneyScript.bankAccount.ToString();

        // Update the interactability of the shop buttons based on the player's purchases and bank account
        if (playerBoughtSword)
        {
            swordOneShopButton.interactable = true;
            // AudioSource.PlayClipAtPoint(buttonSound, transform.position, 1f);
        }
        else if (!playerBoughtSword && (moneyScript.bankAccount >= 0))
        {
            swordOneShopButton.interactable = true;
        }
        else
        {
            swordOneShopButton.interactable = false;
        }

        if (playerBoughtGun)
        {
            gunOneShopButton.interactable = true;
            // AudioSource.PlayClipAtPoint(buttonSound, transform.position, 1f);
        }
        else if (!playerBoughtGun && (moneyScript.bankAccount >= 80))
        {
            gunOneShopButton.interactable = true;
        }
        else
        {
            gunOneShopButton.interactable = false;
        }

        if (playerBoughtSwordTwo)
        {
            swordTwoShopButton.interactable = true;
            // AudioSource.PlayClipAtPoint(buttonSound, transform.position, 1f);
        }
        else if (!playerBoughtSwordTwo && (moneyScript.bankAccount >= 15))
        {
            swordTwoShopButton.interactable = true;
        }
        else
        {
            swordTwoShopButton.interactable = false;
        }
        
        if (playerBoughtSwordThree)
        {
            swordThreeShopButton.interactable = true;
            // AudioSource.PlayClipAtPoint(buttonSound, transform.position, 1f);
        }
        else if (!playerBoughtSwordThree && (moneyScript.bankAccount >= 40))
        {
            swordThreeShopButton.interactable = true;
        }
        else
        {
            swordThreeShopButton.interactable = false;
        }
    }

}
