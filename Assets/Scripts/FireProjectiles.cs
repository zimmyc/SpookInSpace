using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeRepeating("FireProjectile", 0f, fireRate);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke("FireProjectile");
        }
    }

    void FireProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}