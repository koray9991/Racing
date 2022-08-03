using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Car2 : MonoBehaviour
{


    [SerializeField] private Rigidbody Rb;
    [SerializeField] private FixedJoystick Joys;
    [SerializeField] private float MoveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rb.velocity = new Vector3(Joys.Horizontal * MoveSpeed, Rb.velocity.y, Joys.Vertical * MoveSpeed);
        if(Joys.Horizontal!=0 || Joys.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Rb.velocity);
        }
    }
}
