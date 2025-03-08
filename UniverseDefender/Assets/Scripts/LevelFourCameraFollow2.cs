using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourCameraFollow2 : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 offset = new Vector3(0f,0f,-10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.1f;
    private Vector3 origin = new Vector3(600f,500f);

    // Update is called once per frame
    void Update()
    {
        Vector3 targetTransform = new Vector3(target.position.x, target.position.y, target.position.z) + offset + origin;
        transform.position = Vector3.SmoothDamp(transform.position,targetTransform,ref velocity,smoothTime);
    }
}
