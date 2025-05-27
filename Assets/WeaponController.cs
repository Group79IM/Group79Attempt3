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
    [SerializeField] private AudioClip swordWhoosh;

    void Start()
    {
        // if (sword != null)
            swordAnimator = sword.GetComponent<Animator>();
            animator = GetComponent<Animator>();
        // }
    }

    void Update()
    {
        // if player can and does attack
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            // call the attack method
            StartCoroutine(Attack());
            AudioSource.PlayClipAtPoint(swordWhoosh, transform.position, 1f);
            Debug.Log("Attack");
        }

        // old weapon switch code
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

    
    // old shoot script which is moved to LaserTrigger
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

        // set attack animations and variables needed in the sword collissions script
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
