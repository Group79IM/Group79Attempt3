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

    // method to damage player
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        StartCoroutine(RedDamageScreen()); // calling the red damage screen effect on the player pov
        AudioSource.PlayClipAtPoint(playerDamage, transform.position, 0.5f);
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);
        healthBar.fillAmount = healthAmount / 100; //drawing the appropriate health bar
        if (healthAmount <= 0)
        {
            Die();
            Debug.Log("player died");
        }
      
    }

    /**
    * Health bar drawing was learnt and based upon a youtube video
    Reference
    *
    * Author: Jake Makes Games (on Youtube)
    * Location: https://www.youtube.com/watch?v=0tDPxNB2JNs
    * Accessed: 1/5/2025
    */
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
        
        //wait till death sound plays then load death screen
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

        // increasing alpha of the red screen to indicate damage
         while (color.a < 0.3f)
        {
            color.a += Time.deltaTime * fadeSpeed;
            redScreen.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(fadePause);
         
         // decreasing alpha of red screen to remove indication of damage
         while (color.a > 0f)
        {
            color.a -= Time.deltaTime * fadeSpeed;
            redScreen.color = color;
            yield return null;
        }
        
    }
}



