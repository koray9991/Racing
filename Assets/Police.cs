using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Police : MonoBehaviour
{
    public Transform Player;
    NavMeshAgent NavMesh;
    void Start()
    {
        NavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMesh.SetDestination(Player.position);
    }
   
}
