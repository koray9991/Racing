using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car4 : MonoBehaviour
{
    public Transform Target;
    public float FollowSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, FollowSpeed);
        transform.LookAt(Target.transform);
    }
}
