using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    [SerializeField] private AudioClip portalSound;
    int currentSceneNum = 0;

    void Awake()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator PortalSequence()
    {
        AudioSource.PlayClipAtPoint(portalSound, transform.position, 1f);
        Debug.Log("portal sound");
        yield return new WaitForSeconds(portalSound.length);

    }
    

    //  Detecting whether the player has entered the portal
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Portal Collided with Player!");
            StartCoroutine(PortalSequence());
            currentSceneNum++;
            SceneManager.LoadScene(currentSceneNum);
            Debug.Log("Current Scene Number: " + currentSceneNum);
            AudioSource.PlayClipAtPoint(portalSound, transform.position, 1f);
        }
    }
}
