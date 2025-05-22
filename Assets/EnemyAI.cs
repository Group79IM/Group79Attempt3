using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float healthAmount = 100f;
    public Animator animator;

    public float patrolRadius = 5f;
    public float detectionRadius = 7f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public float stopOffset = 0.4f;
    public float attackDamage = 10f;    // Damage per attack

    private NavMeshAgent agent;
    private GameObject player;

    private Vector3 patrolTarget;
    private float patrolWaitTime = 3f;
    private float patrolTimer = 0f;
    private float lastAttackTime = -999f;
    public float attackRangeTolerance = 0.5f;

    private bool isDead = false;
    private bool playerDetected = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetNewPatrolPoint();
        animator.SetBool("alive", true);
    }

    void Update()
    {
        if (isDead) return;

        if (!playerDetected)
        {
            DetectPlayer();
            if (!playerDetected)
            {
                Patrol();
                return;
            }
        }

        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Rotate toward player
        Vector3 lookDirection = player.transform.position - transform.position;
        lookDirection.y = 0;
        if (lookDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }

        if (distanceToPlayer <= attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("walk", false);

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                if (Random.value <= 0.25f){
                    animator.SetTrigger("attack2");
                }
                else
                {
                    animator.SetTrigger("attack");
                }
                
                lastAttackTime = Time.time;
            }
        }
        else
        {
            agent.isStopped = false;
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - directionToPlayer * stopOffset;
            agent.SetDestination(targetPosition);
            animator.SetBool("walk", true);
        }
    }

    void DetectPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                player = hit.gameObject;
                playerDetected = true;
                break;
            }
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            animator.SetBool("walk", false);

            if (patrolTimer >= patrolWaitTime)
            {
                SetNewPatrolPoint();
                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer = 0f;
            animator.SetBool("walk", true);
        }
    }

    void SetNewPatrolPoint()
    {
        Vector2 randomPoint = Random.insideUnitCircle * patrolRadius;
        Vector3 targetPoint = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);

        if (NavMesh.SamplePosition(targetPoint, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        healthAmount -= damage;

        if (healthAmount <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("alive", false);
        isDead = true;

        agent.isStopped = true;
        agent.ResetPath();

        animator.ResetTrigger("attack");
        animator.ResetTrigger("attack2");
        animator.SetBool("walk", false);
        animator.Play("death", 0, 0f);

        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(1.75f);
        transform.Find("coins").gameObject.SetActive(true);
    }

    // This function must be called by an animation event on the fk animation at the exact hit frame
    public void DealDamage(float animDamage)
    {
        if (player == null) return;

        // Check if player is still in attack range (optional but recommended)
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= attackRange + attackRangeTolerance) // a small tolerance
        {
            Interactions playerInteractions = player.GetComponent<Interactions>();
            if (playerInteractions != null)
            {
                playerInteractions.TakeDamage(animDamage);
            }
        }
    }
}
