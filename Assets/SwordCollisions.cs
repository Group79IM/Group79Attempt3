using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{
    bool notHit = true;
    public WeaponController wc;
    
    
    private void OnTriggerStay(Collider other){
        //  Debug.Log(other.name);
        if(other.tag == "Damages" && wc.isAttacking )
        {
            notHit = false;
        //    Debug.Log("yipee");
            other.GetComponent<Animator>().SetTrigger("hit");
            notHit = true;
        }
    }


}
