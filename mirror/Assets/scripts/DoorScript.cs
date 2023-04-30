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
    [SerializeField] TextMeshProUGUI text;

    [Header("Transforms & Scripts")]
    [Space(5)]
    [SerializeField] private KeyScript keyScript;
    [Space(2)]
    [SerializeField] private Transform DoorHolder;

    [Header("Array")]
    [Space(5)]
    [SerializeField] private Transform[] DoorArray;

    private NavMeshObstacle obstacle;
    private Animator animator;
    private bool InTrigger;
    private bool IsOpen;

    public Dictionary<string, bool> DoorNames = new Dictionary<string, bool>();

    private void Start()
    {
        SetDoors();
    }

    private void SetDoors()
    {
        DoorArray = new Transform[DoorHolder.childCount];
        for (int i = 0; i < DoorHolder.childCount; i++)
        {

            DoorArray[i] = DoorHolder.GetChild(i);

            DoorNames.Add(DoorArray[i].name, true);
        }
    }
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
            for (int i = 0; i < keyScript.Keys.Length; ++i)
            {
                if (keyScript.Triggers[keyScript.Keys[i].name] == DoorNames[DoorArray[i].name] && DoorArray[i].name == transform.name)
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

