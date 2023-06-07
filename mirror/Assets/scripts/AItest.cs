using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AItest : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform playerTransform;
    public GameObject EndScreen;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination = playerTransform.position;
        float dist = Vector3.Distance(transform.position, playerTransform.position);

        if(dist < 1f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
