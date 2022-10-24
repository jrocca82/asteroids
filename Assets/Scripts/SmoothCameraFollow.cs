using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Transform playerTrans;
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        playerTrans = GameObject.Find("Fighter").transform;
    }

    void Update()
    {
        Vector3 targetPos = new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
