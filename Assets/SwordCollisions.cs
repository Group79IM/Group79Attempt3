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
        if (other.CompareTag("Damages") && wc.isAttacking && !hasHit)
        {
            Animator enemyAnimator = other.GetComponent<Animator>();
            EnemyAI enemy = other.GetComponent<EnemyAI>();

            if (enemy != null && enemyAnimator != null && !enemyAnimator.GetBool("alive"))
                return;  

            if (enemyAnimator != null)
                enemyAnimator.SetTrigger("hit");

            if (enemy != null)
                        //hit sound

                enemy.TakeDamage(swordDamage);

            hasHit = true; 
        }
    }

    private void Update()
    {
        
        if (!wc.isAttacking && hasHit)
        {
            hasHit = false;
        }
    }
}
