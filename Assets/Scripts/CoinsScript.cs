using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {
    [SerializeField] private GameObject moneyObject;
    private Money moneyScript;

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            Debug.Log("Player collided with coin");
            moneyScript.AddMoney(1);
            Destroy(collision.gameObject);
        }
    }
}
