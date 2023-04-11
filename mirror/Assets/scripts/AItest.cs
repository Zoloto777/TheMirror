using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform playerTransform;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination = playerTransform.position;
    }
}
