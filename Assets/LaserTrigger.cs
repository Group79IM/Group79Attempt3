using System.Collections;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public SimpleLaserController laserController; // assign in inspector or find on parent

    private void Start()
    {
        if (laserController == null)
            laserController = GetComponentInParent<SimpleLaserController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (laserController != null && laserController.laserCylinder.activeSelf && other.CompareTag("Damages"))
        {
            Animator enemyAnim = other.GetComponent<Animator>();
            var enemyScript = other.GetComponent<EnemyAI>();  // Your enemy script

            if (enemyScript != null && enemyAnim != null)
            {
                enemyScript.TakeDamage(laserController.damageAmount);
                enemyAnim.SetTrigger("hit");
            }
        }
    }
}