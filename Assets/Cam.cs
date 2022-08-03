using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Target);
        transform.position = new Vector3(Target.transform.position.x + 2, 15, Target.transform.position.z + 20);
    }
}
