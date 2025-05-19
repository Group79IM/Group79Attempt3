using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{
    bool notHit = true;
    public WeaponController wc;
    
    
    private void OnTriggerStay(Collider other){
        //  Debug.Log(other.name);
        if(other.tag == "Damages" && wc.isAttacking)
        {
            notHit = false;
            other.GetComponent<Animator>().SetTrigger("hit");

             EnemyAI enemy = other.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(1f);
            }

            notHit = true;
        }
    }


}
