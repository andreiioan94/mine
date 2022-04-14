using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 0.125f;

    void LateUpdate()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 camPos = transform.position;
        camPos.y = player.transform.position.y;
        transform.position = camPos;
    }
}
