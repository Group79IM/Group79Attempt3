using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private AudioClip coinPickUP;
    private Money moneyScript;

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Money") || collision.gameObject.CompareTag("BossMoney"))
        {
            Debug.Log("Player collided with coin");
            moneyScript.AddMoney(3);
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(coinPickUP, transform.position, 1f);
        }
        if (collision.gameObject.CompareTag("BossMoney"))
        {
            Debug.Log("Player collided with lots of coins");
            moneyScript.AddMoney(15);
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(coinPickUP, transform.position, 1f);
        }
    }
}
