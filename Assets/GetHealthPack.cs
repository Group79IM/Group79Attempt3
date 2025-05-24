using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHealthPack : MonoBehaviour
{

    public int plusHealth = 50;
    public GameObject healthpack;
    [SerializeField] private AudioClip healSound;



    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interactions>().AddHealth(plusHealth);
            AudioSource.PlayClipAtPoint(healSound, transform.position, 1f);
            healthpack.SetActive(false);
            Debug.Log("healthpack used, healthpack deactivated");
        }
    }
}
