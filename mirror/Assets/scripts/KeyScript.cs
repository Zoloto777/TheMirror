using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [Header("Active Distance")]
    [SerializeField] float ActiveDistance;
    [Header("Transforms & Scripts")]
    [SerializeField] Transform KeyHolder;
    [Space(2)]
    [SerializeField] DoorScript DoorScript;

    [Header("Array")]
    public Transform[] Keys;

    public Dictionary<string, bool> Triggers = new Dictionary<string, bool>();
    // Start is called before the first frame update
    void Start()
    {
        SetKeys();
    }

    private void SetKeys()
    {
        Keys = new Transform[KeyHolder.childCount];
        for(int i = 0; i < KeyHolder.childCount; i++)
        {
            Keys[i] = KeyHolder.GetChild(i);

            Triggers.Add(Keys[i].name, false);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool active = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out RaycastHit hit, ActiveDistance);

        if (!Input.GetKeyDown(KeyCode.E) || !active)
        {
            return;
        }


        if (hit.transform.CompareTag("Item-usable"))
        {
            hit.transform.gameObject.SetActive(false);           
            for (int i = 0; i < Keys.Length; i++)
            {
                if (hit.transform.gameObject.name == Keys[i].name)
                {
                    Triggers[Keys[i].name] = true;
                }
            }
        }
    }
}
