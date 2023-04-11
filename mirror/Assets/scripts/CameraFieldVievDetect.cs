using UnityEngine;
using UnityEngine.AI;


public class CameraFieldVievDetect : MonoBehaviour
{

    [Header("Game Objects")]
    [SerializeField] private NavMeshAgent agent;
    [Space(2)]
    [SerializeField] private GameObject Mirror;

    [Header("Cameras")]
    [SerializeField] private Camera cameraMain;
    [Space(2)]
    [SerializeField] private Camera cameraSecond;

    [Header("Linecast variables")]
    [SerializeField] private Transform Origin;
    [Space(2)]
    [SerializeField] private Transform SecondOrigin;
    [Space(2)]
    [SerializeField] private Transform Destination;

    [Header("OcclusionLayer")]
    [SerializeField] private LayerMask occlusionLayer;

    Plane[] CameraFrustum;
    Plane[] SecondCameraFrustum;
    Collider colliderMain;
    private void Start()
    {
       colliderMain = GetComponent<Collider>();
    }
    private void Update()
    {
        Vector3 origin = Origin.position;
        Vector3 secondOrigin = SecondOrigin.position;
        Vector3 dest = Destination.position;

        agent.isStopped = false;

        var bounds = colliderMain.bounds;
        CameraFrustum = GeometryUtility.CalculateFrustumPlanes(cameraMain);
        SecondCameraFrustum = GeometryUtility.CalculateFrustumPlanes(cameraSecond);

        if (GeometryUtility.TestPlanesAABB(CameraFrustum, bounds) || (GeometryUtility.TestPlanesAABB(SecondCameraFrustum, bounds) && Mirror.activeSelf))
        {
            if (!Physics.Linecast(origin, dest, occlusionLayer) || !Physics.Linecast(secondOrigin, dest, occlusionLayer))
            {
                agent.isStopped = true;
            }
        }
        else
        {
            agent.isStopped = false; 
        }
    }
}