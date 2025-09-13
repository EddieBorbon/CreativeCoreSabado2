using System;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [Header("Rotación horizontal (eje Y)")]
    public float minYaw = -45f;
    public float maxYaw = 45f;

    [Header("Rotación horizontal (eje x)")]
    public float minPitch= -10f;
    public float maxPitch = 30f;

    [Header("Rotación horizontal (eje x)")]
    public float sensivityX = 5f;
    public float sensivityY = 5f;

    private float currentYaw;
    private float currentPitch;

    void Start()
    {
        Vector3 angles = transform.localEulerAngles;
        currentYaw = angles.y;
        currentPitch = angles.x;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensivityY;

        currentYaw += mouseX;
        currentPitch -= mouseY;

        currentYaw = Mathf.Clamp(currentYaw, minYaw, maxYaw);
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
    }
}
