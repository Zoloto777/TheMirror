using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] float ActiveDistance;
    [SerializeField] private NavMeshSurface surface;

    public Animator door;
    public bool IsOpen;

    public void Update()
    {
        door.SetBool("IsOpen", IsOpen); 
        bool active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hit, ActiveDistance);
        
        if (!Input.GetKeyDown(KeyCode.E) || !active)
        {
            return;
        }

        if (!hit.transform.CompareTag("Door"))
        {
            return;
        }
        if (IsOpen)
        {
            DoorClosed();
        }
        else
        {
            DoorOpen();
        }
    

    }

    private void DoorOpen()
    {
        IsOpen = true;

    }

        
    private void DoorClosed()
    {
        IsOpen = false;
    }

}
