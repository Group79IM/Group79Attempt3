using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCoins : MonoBehaviour
{
    public int skeletonMoney = 3;
    public GameObject coins;
    public GameObject moneyObject;
    [SerializeField] private AudioClip plusMoney;
    private Money moneyScript;

    void Awake()
    {
        moneyScript = moneyObject.GetComponent<Money>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Money>().AddMoney(skeletonMoney);
            AudioSource.PlayClipAtPoint(plusMoney, transform.position, 2f);
            coins.SetActive(false);
            Debug.Log("coins picked up, coins deactivated");
        }
    }
}
