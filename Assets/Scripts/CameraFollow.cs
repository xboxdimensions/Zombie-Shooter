using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject amogus;
    
    public float smoothspeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    { 
        amogus = GameObject.FindGameObjectWithTag("Player");
        Transform target = amogus.GetComponent<Transform>();
        Vector3 desiredpos = target.position+offset;
        Vector3 smoothedpos = Vector3.Lerp(transform.position,desiredpos,smoothspeed);
        transform.position = smoothedpos;
        transform.LookAt(target);
    }
}
