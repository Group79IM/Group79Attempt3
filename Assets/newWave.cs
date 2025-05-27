using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class newWave : MonoBehaviour
{
    private int wave = 0;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public GameObject[] healthPacks;
    public int enemiesPerWave = 6;
    public TextMeshPro waveText3D;
    private bool playerInTrigger = false;
    public GameObject fence;
    private List<GameObject> currentEnemies = new List<GameObject>();
    private bool BossWaveFence = false;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip futureBossMusic;

    void Start()
    {
        SpawnWave(); // Spawns the first default wave as the player loads in
    }

    void Update()
    {
        if (wave == 2 && !BossWaveFence) // lets the boss out after three waves
        {
            if (AreAllEnemiesDead())
            {
                fence.GetComponent<Animator>().SetTrigger("open");
                BossWaveFence = true;
                AudioSource.PlayClipAtPoint(futureBossMusic, transform.position, 1f);
                Debug.Log("future boss music playing");
                wave++;
            }
        }

        // if the player interacts with a button
        if (playerInTrigger && Input.GetMouseButtonDown(1))
        {
            TryStartNewWave();
        }
    }

    // checks if all enemies are dead
    bool AreAllEnemiesDead()
    {
        foreach (var enemy in currentEnemies)
        {
            if (enemy != null)
            {
                EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
                if (enemyScript != null && !enemyScript.isDead)
                {
                    return false;
                }
            }
        }
        return true;
    }

    // attempts to create a new wave
   void TryStartNewWave()
{
    // assume all enemies are dead 
    bool allDead = true;

    // check every spawned enemy
    foreach (var enemy in currentEnemies)
    {
        if (enemy != null)
        {
            EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();

            // if the enemy is alive
            if (enemyScript != null && !enemyScript.isDead)
            {
                // cannot start wave yet so reset and break the loop
                allDead = false;
                break;          
            }
        }
    }

        if (!allDead)
        {
            waveText3D.text = "Enemies still remain!";
            StartCoroutine(Wait(1.5f));
            return;
        }

        // update the wave counter and spawn the next wave
        wave++;
        SpawnWave();
        waveText3D.text = "New wave started!";
        AudioSource.PlayClipAtPoint(buttonClick, transform.position, 1f);
        StartCoroutine(Wait(1.5f));
    }

    void SpawnWave()
    {
        // remove last spawn from the list
        currentEnemies.Clear();

        
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            /**
            * Enemy spawning was learnt and based upon a youtube video
            Reference
            *
            * Author: Modding by Kaupenjoe (on Youtube)
            * Location: https://www.youtube.com/watch?v=SELTWo1XZ0c
            * Accessed: 22/5/2025
            */
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            // end of instantiation usage 
            currentEnemies.Add(enemy);
        }
        
        ActivateAllHealthPacks(); // reactive all health packs in a new wave
    }

   // check player trigger for button usage 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = false;
    }

    // shows the wanted message for the set time then returns it to the default button message
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        waveText3D.text = "Press RMB here to Reset Enemy Wave";
    }

    void ActivateAllHealthPacks()
{
    // sets all objects in an array to active if they were used
    foreach (GameObject pack in healthPacks)
    {
        if (pack != null)
            pack.SetActive(true);
    }
}
}