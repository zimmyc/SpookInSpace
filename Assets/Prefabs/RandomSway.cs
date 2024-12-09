using UnityEngine;

public class RandomSway : MonoBehaviour
{
    public float swayAmount = 5f; // Maximum sway angle
    public float swaySpeed = 2f; // Speed of the sway

    private float initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation.eulerAngles.z;
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.localRotation = Quaternion.Euler(0, 0, initialRotation + sway);
    }
}