using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    public Camera cam;

    private Rigidbody drone;

    void Start()
    {
        drone = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            drone.MovePosition(drone.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        drone.MoveRotation(drone.rotation * Quaternion.Euler(rotation));
        if (cam != null) {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
