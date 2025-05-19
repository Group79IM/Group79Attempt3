using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            Debug.Log("Player collided with coin");
            Destroy(collision.gameObject);
            Money bankAccount = FindObjectOfType<Money>();
            bankAccount.AddMoney(1);
        }
    }
}
