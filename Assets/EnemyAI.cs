using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    public GameObject projectilePrefab; // bullet or projectile prefab
    public Transform firePoint;         // where bullets are fired from
    public float shootCooldown = 1.5f;  // time between shots
    public float shootRange = 10f;      // distance within which enemy can shoot
    public float shootSpeed; 

    private float shootTimer = 0f;      // tracks time between shots
    private GameObject player;
    private bool found = false;
    private float distanceAway = 1f;
    private bool inMotion = true;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("HELLOO");
    }

    void Update()
    {
        // shootTimer += Time.deltaTime;

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (found && inMotion)
            {
                agent.destination = player.transform.position + player.transform.forward * distanceAway;
            }

            if (distance > 5f)
            {
                distanceAway = 1f;
            }

//            if (shootTimer >= shootCooldown && found)
// {
                
//                  distance = Vector3.Distance(transform.position, player.transform.position);
//                 if (distance <= shootRange)
//                     {
//                         ShootAtPlayer();
//                         shootTimer = 0f;
//                      }
//             }
//         }
        }

    // void ShootAtPlayer()
    // {
    //     if (projectilePrefab != null && firePoint != null)
    //     {
    //         GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    //         Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //         if (rb != null && player != null)
    //         {
    //             Vector3 direction = (player.transform.position - firePoint.position).normalized;
    //             rb.velocity = direction * shootSpeed; 
    //         }
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
         Debug.Log("hello");
        if (other.gameObject.name ==  "Sword")
        {
            Debug.Log("hello");
            player = other.gameObject;
            found = true;
            distanceAway = 1f;
        }
    }
}


}