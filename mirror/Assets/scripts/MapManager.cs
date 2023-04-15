using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;
    
    // Update is called once per frame
    private void Awake()
    {
        surface.BuildNavMesh();
    }
}
