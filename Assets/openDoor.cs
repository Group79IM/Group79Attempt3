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
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(doorOpen, transform.position, 1f);
            animator.SetBool("open", true);    
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(doorClose, transform.position, 1f);
            animator.SetBool("open", false);
            
        }
    }

}
