using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSelectorScript : MonoBehaviour
{
    public GameObject[] DoorsList; //put all your valves here from the inspector
    List<Animator> animatorList = new List<Animator>();
    [SerializeField] Transform cam;
    [SerializeField] float ActiveDistance;


    public Animator door;
    public bool IsOpen;
    void Start()
    {
        
        if (DoorsList.Length >= 1) //make sure list isn't empty
        {
            for (int i = 0; i < DoorsList.Length; i++) //NOTE: do "valvesList.Length - 1" instead, if you get index out of range error
            {
                animatorList.Add(DoorsList[i].GetComponent<Animator>()); //fill up your list with animators components from valve gameobjects
                animatorList[i].enabled = false; //turn off each animator component at the start
            }
        }
        else
        {
            return; //if list is empty do nothing
        }
    }
    
    public void FindValve(string DoorName)
    {
        if (DoorsList.Length >= 1)
        {
            for (int i = 0; i < DoorsList.Length; i++) //NOTE: do "valvesList.Length - 1" instead, if you get index out of range error
            {
                if (DoorsList[i].name == DoorName)
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
        }
        else
        {
            return;
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
        string valveGameobjectName = hit.transform.name;
            FindValve(valveGameobjectName);
        }
    }

