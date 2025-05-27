using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{

    // This script resets the game by clearing the player's bank account and resetting shop purchases.

    [SerializeField] private GameObject moneyObject;
    [SerializeField] private GameObject shopObject; 
    [SerializeField] private Interactions interactions;
    [SerializeField] private ShopScript shopScript;

    // UI elements
    [SerializeField] private GameObject tutorialObject;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private GameObject menuBacking;

    private Money moneyScript;

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
        shopScript = shopObject.GetComponent<ShopScript>();
        GameReseting();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void GameReseting() // This method resets the game state
    {
        moneyScript.bankAccount = 0;
        shopScript.playerBoughtGun = false;
        shopScript.playerBoughtSword = false;
        shopScript.playerBoughtSwordTwo = false;
        shopScript.playerBoughtSwordThree = false;
    }

    public void EgyptScene() // This is the first scene of the game
    {
        SceneManager.LoadScene(1);
    }
    public void TutorialScene() // This method opens the tutorial scene
    {
        buttonContainer.SetActive(false);
        menuBacking.SetActive(false);
        tutorialObject.SetActive(true);
    }
    public void CloseTutorial() // This method closes the tutorial scene
    {
        tutorialObject.SetActive(false);
        buttonContainer.SetActive(true);
        menuBacking.SetActive(true);
    }
    public void QuitApp()
    {
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
        Application.Quit();
        Debug.Log("Application Has Quit");
    }
}
