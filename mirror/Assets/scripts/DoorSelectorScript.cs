using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DoorSelectorScript : MonoBehaviour
{
    [Header("Interaction Variables")]
    [Space(5)]
    [SerializeField] Transform cam;
    [Space(2)]
    [SerializeField] float ActiveDistance;

    private NavMeshObstacle obstacle;
    private Animator animator;
    private BoxCollider BoxCollider;
    public TextMeshProUGUI text;

    [Header("Door Variable")]
    [Space(5)]
    public bool IsOpen;

    void Awake()
    {
       
        this.obstacle = GetComponent<NavMeshObstacle>();
        this.animator = GetComponent<Animator>();
        this.BoxCollider = GetComponent<BoxCollider>();
    }

    public void FindDoor(string DoorName)
    {
        if (animator.gameObject.tag == DoorName)
        {
            if (IsOpen)
            {
                DoorClosed();
            }
            else
            {
                DoorOpen();
            }
        }
    }

    private void DoorOpen()
    {
        IsOpen = true;
        this.obstacle.enabled = false;
    }


    private void DoorClosed()
    {
        IsOpen = false;
        this.obstacle.enabled = true;
    }

    public void Update()
    {
        animator.SetBool("IsOpen", IsOpen);
        //bool active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hit, ActiveDistance);

        //if (Input.GetKeyDown(KeyCode.E) && active)
        //{
        //    if (hit.transform.CompareTag("Door"))
        //    {
        //        string GameobjectName = hit.transform.parent.name;
        //        FindDoor(GameobjectName);
        //    }
        //}
        
    }

    public void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(BoxCollider.name);
            string GameobjectName = BoxCollider.name;
            FindDoor(GameobjectName);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}

