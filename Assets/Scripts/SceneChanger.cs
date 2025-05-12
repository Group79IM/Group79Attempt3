using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour {
    // [SerializeField] private PlayerInput input;
    // [SerializeField] private GameObject gameObject;
    // private void Awake() {
    //     // input = new PlayerInput();
    //     input.GameUI.Exit.performed += Pause;
    // }
    // void OnEnable() {
    //     input.GameUI.Enable();
    // }
    // void OnDisable() {
    //     input.GameUI.Disable();
    // }
    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application Has Quit");
    } 
    public void SettingsScene() {
        SceneManager.LoadScene(1);
    }
    public void Pause(InputAction.CallbackContext context) {
        Time.timeScale = 0f;
        Enable();
    }
    public void UnPause() {
        Time.timeScale = 1f;
        Disable();
    }
    public void WinningScene() {
        SceneManager.LoadScene(2);
    }
    public void DeathScene() {
        SceneManager.LoadScene(3);
    }
    public void Disable() {
        gameObject.SetActive(false);
    }
    public void Enable() {
        gameObject.SetActive(true);
    }
    public void EgyptScene() {
        SceneManager.LoadScene(4);
    }
    public void FuturisticScene() {
        SceneManager.LoadScene(5);
    }

}
