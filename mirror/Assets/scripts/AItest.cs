using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
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
