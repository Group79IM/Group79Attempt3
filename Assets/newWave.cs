using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    private int wave = 0;

    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 6;

    [Header("3D Text & Player Detection")]
    public TextMeshPro waveText3D;
    private bool playerInTrigger = false;

    [Header("Fence GameObject")]
    public GameObject fence;

    private List<GameObject> currentEnemies = new List<GameObject>();

    private bool firstWaveFenceDisabled = false;

    void Start()
    {
        SpawnWave(); // Spawn first wave
        // No waveText3D "Wave started!" on first wave as requested
    }

    void Update()
    {
        if (wave == 0 && !firstWaveFenceDisabled)
        {
            if (AreAllEnemiesDead())
            {
                Debug.Log("First wave complete, disabling fence.");
                fence.SetActive(false);
                firstWaveFenceDisabled = true;
                wave++;
            }
        }

        if (playerInTrigger && Input.GetMouseButtonDown(1))
        {
            TryStartNewWave();
        }
    }

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

    void TryStartNewWave()
    {
        bool allDead = true;

        foreach (var enemy in currentEnemies)
        {
            if (enemy != null)
            {
                EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
                if (enemyScript != null && !enemyScript.isDead)
                {
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

        wave++;
        SpawnWave();
        waveText3D.text = "Wave started!";
        StartCoroutine(Wait(1.5f));
    }

    void SpawnWave()
    {
        currentEnemies.Clear();

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            currentEnemies.Add(enemy);
        }
    }

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

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        waveText3D.text = "Press Right Click to Reset Enemy Wave";
    }
}
