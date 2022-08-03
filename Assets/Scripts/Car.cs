using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float MoveSpeed;
    private Vector3 MoveForce;
    public float MaxSpeed;
    public float Drag;
    public float steerAngle;
    private void FixedUpdate()
    {
        MoveForce += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime*MoveSpeed;
        transform.position += MoveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
    }
}
