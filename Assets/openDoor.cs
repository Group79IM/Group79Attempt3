using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animation animationComponent;
    public string clipName = "doorOpening";
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animationComponent.Play(clipName);
        }
    }

}
