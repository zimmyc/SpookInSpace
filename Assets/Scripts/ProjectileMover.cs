using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 15f;
    public float lifespan = 8f; // Lifespan of the projectile in seconds

    void Start()
    {
        // Destroy the projectile after its lifespan
        Destroy(gameObject, lifespan);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        // Move the projectile in the set direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}