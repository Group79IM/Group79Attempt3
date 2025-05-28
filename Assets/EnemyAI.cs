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
    public float attackDamage = 10f;   
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 patrolTarget;
    private float patrolWaitTime = 3f;
    private float patrolTimer = 0f;
    private float lastAttackTime = -999f;
    public float attackRangeTolerance = 0.5f;
    public bool isDead = false;
    private bool playerDetected = false;
    [SerializeField] private AudioClip enemyDamage;
    [SerializeField] private AudioClip coinDrop;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetNewPatrolPoint();
        animator.SetBool("alive", true);
    }

    void Update()
    {
        if (isDead) {
            return;
        }

        // begins patrol when player is found
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

        // rotates enemy towards the player
        Vector3 lookDirection = player.transform.position - transform.position;
        lookDirection.y = 0;
        if (lookDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }

        // attacks the player when close enough
        if (distanceToPlayer <= attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("walk", false);

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // 32% chance to perform  second attack variant 
                if (Random.value <= 0.32f){
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
            // sets bool for walking to true to animate and continue walking
            agent.isStopped = false;
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - directionToPlayer * stopOffset;
            agent.SetDestination(targetPosition);
            animator.SetBool("walk", true);   
        }
    }

    void DetectPlayer()
    {
        // checks if player has been detected yet
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
        // if enemy is close enough to the needed destination stop walking
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            animator.SetBool("walk", false);

            // if the cooldown for new patrol point is done create a new one
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
        //creates a random target point for the enemy ai to go to
        Vector2 randomPoint = Random.insideUnitCircle * patrolRadius;
        Vector3 targetPoint = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);

        if (NavMesh.SamplePosition(targetPoint, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    public void TakeDamage(float damage)
    {
        // checks if the enemy has been hit, called in the player weapon collisions
        if (isDead){ 
            return;
        }

        healthAmount -= damage;
        AudioSource.PlayClipAtPoint(enemyDamage, transform.position, 1f);
        
        // calls death sequence if the enemy has lost all health
        if (healthAmount <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // resets all animation triggers and navigation 
        animator.SetBool("alive", false);
        isDead = true;

        agent.isStopped = true;
        agent.ResetPath();

        animator.ResetTrigger("attack");
        animator.ResetTrigger("attack2");
        animator.SetBool("walk", false);
        animator.Play("death", 0, 0f);

        StartCoroutine(Kill());
        AudioSource.PlayClipAtPoint(coinDrop, transform.position, 1f);
    }

    IEnumerator Kill()
    {
        // spawns coins after an appropriate amount of time
        yield return new WaitForSeconds(1.75f);
        transform.Find("coins").gameObject.SetActive(true);
        // Destroy(gameObject, 12.5f);
    }


    public void DealDamage(float animDamage)
    {

        if (player == null) {
            return;
        }
        //distance between enemy and player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        // if the player is within range accounting for damage tolerance then cause damage 
        if (distanceToPlayer <= attackRange + attackRangeTolerance) 
        {
            Interactions playerInteractions = player.GetComponent<Interactions>();
            if (playerInteractions != null)
            {
                playerInteractions.TakeDamage(animDamage);
                
            }
        }
    }
}
