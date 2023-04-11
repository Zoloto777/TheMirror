using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform FirstPersonPlayer;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = FirstPersonPlayer.position + offset;
    }
}
