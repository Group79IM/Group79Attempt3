using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{

    public float swordDamage = 20f;
    public WeaponController wc;
    private bool hasHit = false;  
  
    private void OnTriggerStay(Collider other)
    {
        // if sword is in enemy collider and is hitting and has not already hit
        if (other.CompareTag("Damages") && wc.isAttacking && !hasHit) 
        {
            Animator enemyAnimator = other.GetComponent<Animator>();
            EnemyAI enemy = other.GetComponent<EnemyAI>();

            // if the enemmy is dead or has no animator return
            if (enemy != null && enemyAnimator != null && !enemyAnimator.GetBool("alive")){
                return;  
            }     
            // if the enemy has an animator hit
            if (enemyAnimator != null){
                enemyAnimator.SetTrigger("hit");
            }
            // if the enemy exists damage it according to the current sword
            if (enemy != null){
                enemy.TakeDamage(swordDamage);
            }
            hasHit = true; // set to true to prevent multiple hits from one sword swing
        }
    }

    private void Update()
    {
        // automatically prevent multiple hits from one sword swing
        if (!wc.isAttacking && hasHit)
        {
            hasHit = false;
        }
    }
}
