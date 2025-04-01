using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using Cinemachine;


public class Interactions : MonoBehaviour
{
    // interaction case 
    public string interaction = "0";

    // flags
    private bool isPlayerNear = false; // flag for if the player is in a collider
    private bool hasCharge = false; // flag for if the player has the electrical charge equipped
    
    // health bar components
    public Image healthBar;
    public float healthAmount = 100f;
  

    // identifier for current interaction number
    public int interactionNumber = 0;

     void Start()
    {  
        }


    void Update()
    {
        Debug.Log(healthAmount);

    }   

 

    void OnTriggerStay(Collider other)
    {   
        // checks if the player is in a damaging collider (e.g fire or loose electricity)
        if (other.CompareTag("Damages") && !other.CompareTag("Interactables") && !other.CompareTag("Door")) 
        {
            TakeDamage(1f); // damages player by the rate of 0.4 health
        }
    }

     void TakeDamage(float damage){
        healthAmount -= damage;
    }




}

   
