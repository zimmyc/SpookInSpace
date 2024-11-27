using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        transform.position = cameraTransform.position;
    }
}