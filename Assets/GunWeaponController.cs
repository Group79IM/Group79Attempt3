using System.Collections;
using UnityEngine;

public class GunWeaponController : MonoBehaviour
{
    [Tooltip("Assign the Laser Cylinder gameobject (child of Gun) here")]
    public GameObject laserCylinder;
    [SerializeField] private AudioClip laserSound;
    // gun functionality variables
    public float burstDuration = 0.025f;   
    public float cooldown = 0.05f;       
    public float damageAmount = 10f;    
    private bool canShoot = true;

    void Start()
    {
        if (laserCylinder != null){ 
            laserCylinder.SetActive(false); // activate laser
        }
        else{
            Debug.LogWarning("LaserCylinder is not assigned!");
        }
    }

    void Update()
    {   
        if (Input.GetMouseButton(0) && canShoot)  // if player shoots
        {
            StartCoroutine(FireBurst()); // call shoot script
        }
    }

    IEnumerator FireBurst()
    {
        //shoot laser
        canShoot = false;
        AudioSource.PlayClipAtPoint(laserSound, transform.position, 0.5f);
        laserCylinder.SetActive(true);

        // disable the laser after chosen time
        yield return new WaitForSeconds(burstDuration);
        laserCylinder.SetActive(false);

        // prevent shooting until gun cooldown is compelted
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
        
    }
}