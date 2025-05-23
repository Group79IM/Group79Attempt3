using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject sword; 
    public GameObject laser;
    public GameObject gun;
    public float attackCooldown = 1f;
    public Animator animator;

    private bool canAttack = true;
    [HideInInspector]
    public bool isAttacking = false;

    private Animator swordAnimator;

    public bool swordEquipped = false;

    public float animationLength;

    void Start()
    {
        // if (sword != null)
            swordAnimator = sword.GetComponent<Animator>();
            animator = GetComponent<Animator>();
        // }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && canAttack )
        {
            StartCoroutine(Attack());
        }

    

        // //weapon switch
        // if (Input.GetKeyDown(KeyCode.Alpha1) && swordEquipped == false)
        // {
        //     gun.SetActive(false);
        //     laser.SetActive(false);
        //     sword.SetActive(true);
        //     swordEquipped = true;
        // }
        //  if (Input.GetKeyDown(KeyCode.Alpha2) && swordEquipped == true)
        // {
        //     sword.SetActive(false);
        //     gun.SetActive(true);
        //     laser.SetActive(false);
        //     swordEquipped = false;
        // }
    }

    // void shoot(){
    //     laser.SetActive(true);
    // }
    // void stopShooting(){
    //     laser.SetActive(false);
    // }

    IEnumerator Attack()
    {
        canAttack = false;
        isAttacking = true;

        if (animator != null)
        {
            animator.SetTrigger("attack");

            animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);
        }

        isAttacking = false;
        canAttack = true;
    }
}
