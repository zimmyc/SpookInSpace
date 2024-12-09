using UnityEngine;

public class DirectionalSway : MonoBehaviour
{
    public float swayAmount = 5f; // Maximum sway distance
    public float swaySpeed = 2f; // Speed of the sway

    private Vector3 initialPosition;
    private Vector3 swayDirection;

    void Start()
    {
        initialPosition = transform.localPosition;
        ChooseRandomDirection();
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.localPosition = initialPosition + swayDirection * sway;

        // Optionally, change direction at intervals
        if (Random.Range(0f, 1f) < 0.01f) // Adjust probability as needed
        {
            ChooseRandomDirection();
        }
    }

    void ChooseRandomDirection()
    {
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0:
                swayDirection = Vector3.up;
                break;
            case 1:
                swayDirection = Vector3.down;
                break;
            case 2:
                swayDirection = Vector3.left;
                break;
            case 3:
                swayDirection = Vector3.right;
                break;
        }
    }
}