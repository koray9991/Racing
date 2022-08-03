using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car3 : MonoBehaviour
{
    public FixedJoystick Joys;
    public float Speed;
    public float TurnSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
    }
 public  void JoystickMovement()
    {
        float horizontal = Joys.Horizontal;
        float vertical = Joys.Vertical;
        Vector3 addedPos = new Vector3(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime);
    }
}
