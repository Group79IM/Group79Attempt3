using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using Cinemachine;


public class Interactions : MonoBehaviour
{





     void Start()
    {  
        }


    void Update()
    {

    }   

 

    void OnTriggerStay(Collider other)
    {   
        // checks if the player is in a damaging collider (
        if (other.CompareTag("Damages")) 
        {
            TakeDamage(0.1f); // damages player at a rate
        }
    }

     void TakeDamage(float damage){
        healthAmount -= damage;
         healthBar.fillAmount = healthAmount / 100f;
    }




}

   
