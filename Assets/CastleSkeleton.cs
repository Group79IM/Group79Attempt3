using UnityEngine;
using UnityEngine.AI;

public class RandomWalker : MonoBehaviour
{
    public float walkRadius = 10f;
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;
    public float destinationTimeout = 5f;

    private NavMeshAgent agent;
    private Animator animator;
    private float idleTimer;
    private float destinationTimer;
    private bool isIdling = false;
    private float checkStuckTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ChooseNewDestination();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isIdling)
            {
                isIdling = true;
                idleTimer = Random.Range(minIdleTime, maxIdleTime);
                animator.SetTrigger("idle");
            }
            else
            {
                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0f)
                {
                    ChooseNewDestination();
                    isIdling = false;
                    animator.SetTrigger("walk");
                }
            }
        }
        else
        {
        
            destinationTimer += Time.deltaTime;

            if (destinationTimer >= destinationTimeout)
            {
     
                ChooseNewDestination();
                destinationTimer = 0f;
            }
        }
    }

    void ChooseNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit navHit, walkRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(navHit.position);
        }

        animator.SetTrigger("walk");
        destinationTimer = 0f;
    }
}
