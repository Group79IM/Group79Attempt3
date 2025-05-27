using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
   
    void Start(){
         animator = GetComponent<Animator>();
    }
    
    // check if player is in door collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             // opens the door
            AudioSource.PlayClipAtPoint(doorOpen, transform.position, 1f);
            animator.SetBool("open", true);    
        }
    }

    // check if player left a door collider
     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // closes the door
            AudioSource.PlayClipAtPoint(doorClose, transform.position, 1f);
            animator.SetBool("open", false);
            
        }
    }

}
