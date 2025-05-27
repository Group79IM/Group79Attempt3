using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{

    // This script manages scene transitions and the pause menu functionality

    [SerializeField] private Group79Game input;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip portalSound;

    public bool menuOpen = false;
    private Money moneyScript;
    private void Awake()
    {
        input = new Group79Game();
        input.GameUI.Exit.performed += PauseMenuManagement;

    }
    void OnEnable()
    {
        input.GameUI.Enable();
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
    }
    void OnDisable()
    {
        input.GameUI.Disable();
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
    }
    public void MainMenu()
    {
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitApp()
    {
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
        Application.Quit();
        Debug.Log("Application Has Quit");
    }
    public void SettingsScene()
    {
        // SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
        Time.timeScale = 0f;
        Enable();
    }
    public void UnPause()
    {
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
        Time.timeScale = 1f;
        Disable();
    }
    public void WinningScene()
    {
        SceneManager.LoadScene(3);
    }
    public void DeathScene()
    {
        SceneManager.LoadScene(4);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
        menuOpen = false;
    }
    public void Enable()
    {
        gameObject.SetActive(true);
        menuOpen = true;
    }
    public void EgyptScene()
    {
        SceneManager.LoadScene(1);
        // AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
    }
    public void FuturisticScene()
    {
        SceneManager.LoadScene(2);
    //     AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
    }
    public void PlayButton()
    {
        
    }
    public void PauseMenuManagement(InputAction.CallbackContext context) // Opening and closing the pause menu, while changing the timescale
    {
        if (menuOpen == false)
        {
            menuOpen = true;
            Pause();
        }
        else
        {
            menuOpen = false;
            UnPause();
        }
    }

}
