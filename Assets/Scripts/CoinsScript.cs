using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {

    // This script handles the player's interaction with coins, allowing them to collect money when colliding with coin objects.

    [SerializeField] private GameObject moneyObject; // Reference to the Money object for managing player's bank account
    [SerializeField] private AudioClip coinPickUP;
    private Money moneyScript; // Reference to the Money script to manage the player's bank account

    void Awake() // 
    {
        moneyScript = moneyObject.GetComponent<Money>();
    }
    void OnCollisionEnter(Collision collision) // Collecting coins when the player collides with them, increasing the back account, destroying the coin object, and playing a sound effect
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            Debug.Log("Player collided with coin");
            moneyScript.AddMoney(3);
            AudioSource.PlayClipAtPoint(coinPickUP, transform.position, 1f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BossMoney"))
        {
            Debug.Log("Player collided with lots of coins");
            moneyScript.AddMoney(15);
            AudioSource.PlayClipAtPoint(coinPickUP, transform.position, 1f);
            Destroy(collision.gameObject);
        }
    }
}
