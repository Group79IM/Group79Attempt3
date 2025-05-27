using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealthPack : MonoBehaviour
{

    public int plusHealth = 50;
    public GameObject healthpack;
    [SerializeField] private AudioClip healSound;

    // when entering health pack collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interactions>().AddHealth(plusHealth); // add player called health
            AudioSource.PlayClipAtPoint(healSound, transform.position, 1f); // play audio
            healthpack.SetActive(false); // disable healthpack
            Debug.Log("healthpack used, healthpack deactivated"); 
        }
    }
}
