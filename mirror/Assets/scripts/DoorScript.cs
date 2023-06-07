using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;


public class DoorScript : MonoBehaviour
{
    [Header("UI")]
    [Space(5)]
    
    public bool IsOpen;

    private NavMeshObstacle obstacle;
    private Animator animator;
    private bool InTrigger;
    

    public Inventory Inventory;

    public enum LockType
    {
        RedDoor,
        GreenDoor,
        YellowDoor
    }
    [SerializeField] LockType lockType;
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
        if (!InTrigger)
        {
            return;
        }

        foreach (KeyScript key in Inventory.Keys)
        {
            if (key.lockType == lockType)
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
    }
    public void OnTriggerEnter()
    {     
        InTrigger = true;
    }

    public void OnTriggerExit()
    {
        InTrigger = false;
    }

}

