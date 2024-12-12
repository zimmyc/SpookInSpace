using UnityEngine;

public class ShootingTrigger : MonoBehaviour
{
    public MonsterShooter monsterShooter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            monsterShooter.StartShooting();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            monsterShooter.StopShooting();
        }
    }
}