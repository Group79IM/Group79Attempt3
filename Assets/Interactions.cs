using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Interactions : MonoBehaviour
{
    public float healthAmount = 100f;
    public Image healthBar;

void Update()
{
    if (healthAmount <= 0)
    {
        ReloadScene();
    }
}

void ReloadScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);
        healthBar.fillAmount = healthAmount / 100f;

        Debug.Log($"Player took {damage} damage, health now: {healthAmount}");

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
        // Add your player death logic here (disable movement, play animation, reload scene, etc.)
    }
}
