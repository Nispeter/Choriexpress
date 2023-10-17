using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mathf;

public class PlayerCamera : MonoBehaviour
{
    private Transform player;
    public float sensX;
    public float sensY;

    public float xRotation = 0f;
    public float yRotation = 0f;

    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.1f;
    private float dampingSpeed = 2.0f;
    Vector3 initialPosition;


    private void Start()
    {
        player = transform.root;
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if(!DayManager.Instance.InGameUI.activeSelf){
            return;
        }
        HandleShake();
        HandleInput();

    }

    private void HandleInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation -= mouseY;
        xRotation = mouseX;

        yRotation = Mathf.Clamp(yRotation, -80f, 80f);
        transform.localEulerAngles = Vector3.right * yRotation;
        player.Rotate(Vector3.up * xRotation);
    }

    private void HandleShake()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void CameraShake(float duration, float magnitude)
    {
        shakeMagnitude = magnitude;
        shakeDuration = duration;
    }
}
