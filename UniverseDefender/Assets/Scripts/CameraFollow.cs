using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 offset = new Vector3(0f,0f,-10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;

    private float timer = 0f;
    private float timerMax = 4f;

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x,target.position.y+4.5f,-10f)+offset;
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothTime);

        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            transform.position = new Vector3(0f,20f,-10f);
            enabled=false;
        }
    }
}
