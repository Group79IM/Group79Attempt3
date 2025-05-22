using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{

    public float swordDamage = 20f;

    public WeaponController wc;

    private bool hasHit = false;  // Tracks if we've hit during current swing

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Damages") && wc.isAttacking && !hasHit)
        {
            Animator enemyAnimator = other.GetComponent<Animator>();
            EnemyAI enemy = other.GetComponent<EnemyAI>();

            if (enemy != null && enemyAnimator != null && !enemyAnimator.GetBool("alive"))
                return;  // Don't hit dead enemies

            if (enemyAnimator != null)
                enemyAnimator.SetTrigger("hit");

            if (enemy != null)
                enemy.TakeDamage(swordDamage);

            hasHit = true;  // Mark that we've already hit this swing
        }
    }

    private void Update()
    {
        // Reset when attack ends so we can hit again on next swing
        if (!wc.isAttacking && hasHit)
        {
            hasHit = false;
        }
    }
}
