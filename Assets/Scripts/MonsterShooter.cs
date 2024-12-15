using System.Collections;
using UnityEngine;

public class MonsterShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingInterval = 2f;
    public float projectileSpeed = 10f;
    private bool isShooting = false;
    private Coroutine shootingCoroutine;

    void Start()
    {
        // Initially, the monster is not shooting
        isShooting = false;
    }

    public void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;
            shootingCoroutine = StartCoroutine(ShootRandomly());
        }
    }

    public void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
        isShooting = false;
    }

    IEnumerator ShootRandomly()
    {
        while (isShooting)
        {
            yield return new WaitForSeconds(shootingInterval);
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(projectileSpeed, Random.Range(-1f, 1f));
            }
        }
        else
        {
            Debug.LogWarning("Projectile prefab is not assigned.");
        }
    }
}