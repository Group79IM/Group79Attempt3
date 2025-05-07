using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    int currentSceneNum = 0;
    
    void Awake() {
        currentSceneNum = SceneManager.sceneCount;
    }

    //  Detecting whether the player has entered the portal
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Portal Collided with Player!");
            currentSceneNum++;
            SceneManager.LoadScene(currentSceneNum);
        }
    }
}
