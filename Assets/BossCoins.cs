using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoins : MonoBehaviour
{
    public int bossMoney = 30;
    public GameObject coins;
    [SerializeField] private AudioClip plusMoney;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Money>().AddMoney(bossMoney);
            AudioSource.PlayClipAtPoint(plusMoney, transform.position, 2f);
            coins.SetActive(false);
            Debug.Log("coins picked up, coins deactivated");
        }
    }



}
