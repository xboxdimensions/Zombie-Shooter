using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public Vector2 turn;
    public float sens = 0.5f;
    // Update is called once per frame
    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sens;
        turn.x += Input.GetAxis("Mouse X") * sens;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
