using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class LocatorScript : MonoBehaviour
{

    [Header("Radio room")]
    [SerializeField] public GameObject radioroom;

    [Header("Timer variables")]
    public bool IsRunning;
    [SerializeField]private float timerTime;
    [Space(2)]
    [SerializeField] private float staticTime;
    [Space(2)]
    [SerializeField] private float distTraveled;

    private Renderer Renderer;
 


    void Start()
    {
        InitialDistance();
        Renderer = GetComponent<Renderer>();
        IsRunning = true;      
    }

    private void Update()
    {
        GetDistance();
        if (timerTime > 0)
        {
            timerTime -= Time.deltaTime;
        }
        else
        {
            if (Renderer.material.color != Color.white)
            {
                Renderer.material.color = Color.white;
            }
            else
            {
                Renderer.material.color = Color.red;
            }
            timerTime = 0;
            IsRunning = false;
        }

        if (timerTime == 0)
        {
            timerTime = staticTime;
            IsRunning = true;
        }
    }

    void GetDistance()
    {
        float dist = Vector3.Distance(radioroom.transform.position, transform.position);
        int distInt = (int)dist;

        if (distInt % 5 == 0)
        {
           if (distInt > distTraveled)
           {
               staticTime += 0.2f;
               distTraveled = distInt;
           }
           else if (distInt < distTraveled)
           {
               staticTime -= 0.2f;
               distTraveled = distInt;
           }
        }

        if (distTraveled >= 100)
        {
            staticTime = 4f;
        }

        if (staticTime < 0)
        {
            staticTime = 0;
        }
    }

    
    void InitialDistance()
    {
        float dist = Vector3.Distance(radioroom.transform.position, transform.position);
        int distInt = (int)dist;

        while(distInt % 5 != 0)
        {
            distInt -= 1;
        }
        distTraveled = distInt;
        staticTime = distTraveled / 5f * 0.2f;

        if (distTraveled >= 100)
        {
            staticTime = 4f;
        }
    }
}
