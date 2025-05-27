using System.Collections;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GunWeaponController laserController; 


    private void Start()
    {
        if (laserController == null)
            laserController = GetComponentInParent<GunWeaponController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (laserController != null && laserController.laserCylinder.activeSelf && other.CompareTag("Damages")) // if the laser is on and touching an enemy
        {
            Animator enemyAnim = other.GetComponent<Animator>(); 
            var enemyScript = other.GetComponent<EnemyAI>();

            if (enemyScript != null && enemyAnim != null)
            {
                enemyScript.TakeDamage(laserController.damageAmount); // damage the enemy
                enemyAnim.SetTrigger("hit"); // make the enemy animate being damaged
            }
        }
    }
}