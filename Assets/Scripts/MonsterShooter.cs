using System.Collections;
using UnityEngine;

public class MonsterShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
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
            StartCoroutine(ShootRandomly());
        }
    }

    public void StopShooting()
    {
        isShooting = false;
        StopCoroutine(ShootRandomly());
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
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(projectileSpeed, Random.Range(-1f, 1f));
        }
    }
}