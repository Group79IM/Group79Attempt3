using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Interactions : MonoBehaviour
{
    public float healthAmount = 100;
    public Image healthBar;
    [SerializeField] private AudioClip playerDamage;
    [SerializeField] private AudioClip gong;

    public Image redScreen;         
    public float fadeSpeed = 1f;
      public float fadePause = 0f;

    // void Update()
    // {
    //     if (healthAmount <= 0)
    //     {
    //         Die();
    //     }
    // }


    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        StartCoroutine(RedDamageScreen());
        AudioSource.PlayClipAtPoint(playerDamage, transform.position, 1f);
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);
        healthBar.fillAmount = healthAmount / 100;
        if (healthAmount <= 0)
        {
            Die();
            Debug.Log("player died");
        }
      
    }

    public void AddHealth(int plusHealth)
    {
        healthAmount += plusHealth;
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);
        healthBar.fillAmount = healthAmount / 100;
    }

    IEnumerator DeathSequence()
    {
        AudioSource.PlayClipAtPoint(gong, transform.position, 1f);
        Debug.Log("dying sound");
        yield return new WaitForSeconds(gong.length);
        SceneManager.LoadScene(4); // death screen
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0); // back to main menu screen
        
    }
    void Die()
    {
        StartCoroutine(DeathSequence());
        Debug.Log("starting coroutine");
    }

    IEnumerator RedDamageScreen()
    {
         Color color = redScreen.color;

         while (color.a < 0.3f)
        {
            color.a += Time.deltaTime * fadeSpeed;
            redScreen.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(fadePause);
         
         while (color.a > 0f)
        {
            color.a -= Time.deltaTime * fadeSpeed;
            redScreen.color = color;
            yield return null;
        }
        
    }
}



