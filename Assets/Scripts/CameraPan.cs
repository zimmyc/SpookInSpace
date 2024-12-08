using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed = 20f;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        virtualCamera.transform.position += move * panSpeed * Time.deltaTime;
    }
}