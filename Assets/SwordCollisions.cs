using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{

    public WeaponController wc;
    
    
    private void OnTriggerStay(Collider other){
        //  Debug.Log(other.name);
        if(other.tag == "Damages" && wc.isAttacking)
        {
        //    Debug.Log("yipee");
            other.GetComponent<Animator>().SetTrigger("hit");
            
        }
    }


}
