using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Group79Game input;
    [SerializeField] private GameObject gameObject;
    public bool menuOpen = false;
    private void Awake()
    {
        input = new Group79Game();
        input.GameUI.Exit.performed += PauseMenuManagement;
    }
    void OnEnable()
    {
        input.GameUI.Enable();
    }
    void OnDisable()
    {
        input.GameUI.Disable();
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application Has Quit");
    }
    public void SettingsScene()
    {
        // SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        Enable();
    }
    public void UnPause()
    {
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
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void EgyptScene()
    {
        SceneManager.LoadScene(1);
    }
    public void FuturisticScene()
    {
        SceneManager.LoadScene(2);
    }
    public void PauseMenuManagement(InputAction.CallbackContext context)
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
