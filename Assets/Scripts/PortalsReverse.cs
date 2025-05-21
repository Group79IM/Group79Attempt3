using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalsReverse : MonoBehaviour
{
    int currentSceneNum = 0;

    void Awake()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    //  Detecting whether the player has entered the portal
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Portal Collided with Player!");
            currentSceneNum--;
            SceneManager.LoadScene(currentSceneNum);
            Debug.Log("Current Scene Number: " + currentSceneNum);
        }
    }
}
