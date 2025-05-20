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
    void Update()
    {
        coinNumText.text = moneyScript.bankAccount.ToString();
    }
}
