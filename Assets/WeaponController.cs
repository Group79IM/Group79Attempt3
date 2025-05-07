using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject sword; // Reference to the sword GameObject
    public float attackCooldown = 1f;

    private bool canAttack = true;
    [HideInInspector]
    public bool isAttacking = false;

    private Animator swordAnimator;

    void Start()
    {
        if (sword != null)
        {
            swordAnimator = sword.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        isAttacking = true;

        if (swordAnimator != null)
        {
            swordAnimator.SetTrigger("attack");
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        canAttack = true;
    }
}
