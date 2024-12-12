using System.Collections;
using UnityEngine;

public class MonsterShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform player;
    public float shootingInterval = 2f;
    public float projectileSpeed = 10f;
    private bool isShooting = false;

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
            StartCoroutine(ShootAtPlayer());
        }
    }

    public void StopShooting()
    {
        isShooting = false;
        StopCoroutine(ShootAtPlayer());
    }

    IEnumerator ShootAtPlayer()
    {
        while (isShooting)
        {
            yield return new WaitForSeconds(shootingInterval);
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (player != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 direction = (player.position - transform.position).normalized;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }
}