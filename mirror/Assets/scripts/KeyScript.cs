using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class KeyScript : MonoBehaviour
{
     public DoorScript.LockType lockType;
     public GameObject otherGameObject;
    [SerializeField] int ActiveDistance;
    [SerializeField] Camera Camera;
    [SerializeField] Inventory Inventory;
   

    void Update()
    {
        bool active = Physics.Raycast(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), out RaycastHit hit, ActiveDistance);

        if (!Input.GetKeyDown(KeyCode.E) || !active)
        {
            return;
        }

        if (hit.transform.CompareTag("Key"))
        { 
            hit.transform.gameObject.SetActive(false);      
            KeyScript key = hit.transform.GetComponent<KeyScript>();
            Inventory.Keys.Add(key);
        }
    }
}
