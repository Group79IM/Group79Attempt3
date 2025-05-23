using System.Collections;
using UnityEngine;

public class SimpleLaserController : MonoBehaviour
{
    [Tooltip("Assign the Laser Cylinder gameobject (child of Gun) here")]
    public GameObject laserCylinder;

    public float burstDuration = 0.3f;   
    public float cooldown = 0.5f;       
    public float damageAmount = 10f;    

    private bool canShoot = true;
    [SerializeField] private AudioClip gunOneShot;

    void Start()
    {
        if (laserCylinder != null)
            laserCylinder.SetActive(false);
        else
            Debug.LogWarning("LaserCylinder is not assigned!");
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(FireBurst());
        }
    }

    IEnumerator FireBurst()
    {
        canShoot = false;
        laserCylinder.SetActive(true);

        yield return new WaitForSeconds(burstDuration);

        laserCylinder.SetActive(false);

        yield return new WaitForSeconds(cooldown);

        canShoot = true;
        AudioSource.PlayClipAtPoint(gunOneShot, transform.position, 1f);
    }
}