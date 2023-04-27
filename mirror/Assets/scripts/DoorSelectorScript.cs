using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DoorSelectorScript : MonoBehaviour
{
    [Header("Door Variable")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private bool IsOpen;

    private NavMeshObstacle obstacle;
    private Animator animator;
    private bool InTrigger;

    void Awake()
    {
       
        this.obstacle = GetComponent<NavMeshObstacle>();
        this.animator = GetComponent<Animator>();
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
        if (InTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
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

    public void OnTriggerEnter()
    {
        text.gameObject.SetActive(true);
        InTrigger = true;
    }

    public void OnTriggerExit()
    {
        text.gameObject.SetActive(false);
        InTrigger = false;
    }
}

