using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject sword; 
    public GameObject laser;
    public GameObject gun;
    public float attackCooldown = 1f;

    private bool canAttack = true;
    [HideInInspector]
    public bool isAttacking = false;

    private Animator swordAnimator;

    public bool swordEquipped = false;

    void Start()
    {
        // if (sword != null)
            swordAnimator = sword.GetComponent<Animator>();
        // }
    }

    void Update()
    {
        //sword hit
        if (Input.GetMouseButtonDown(0) && canAttack && swordEquipped == true)
        {
            StartCoroutine(Attack());
        }

        //gun shooting
        if (Input.GetMouseButtonDown(0) && swordEquipped == false)
        {
            shoot();
        }
        if (Input.GetMouseButtonUp(0) && swordEquipped == false)
        {
            stopShooting();
        }

        //weapon switch
        if (Input.GetKeyDown(KeyCode.Alpha1) && swordEquipped == false)
        {
            gun.SetActive(false);
            laser.SetActive(false);
            sword.SetActive(true);
            swordEquipped = true;
        }
         if (Input.GetKeyDown(KeyCode.Alpha2) && swordEquipped == true)
        {
            sword.SetActive(false);
            gun.SetActive(true);
            laser.SetActive(false);
            swordEquipped = false;
        }
    }

    void shoot(){
        laser.SetActive(true);
    }
    void stopShooting(){
        laser.SetActive(false);
    }

    IEnumerator Attack()
    {
        canAttack = false;
        isAttacking = true;

        if (swordAnimator != null  && sword != null)
        {
            swordAnimator.SetTrigger("attack");
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        canAttack = true;
    }
}
