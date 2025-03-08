using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourCameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    private Vector3 offset = new Vector3(0f,0f,-10f);

    private Vector3 velocity = Vector3.zero;

    private float smoothTime = 0.25f;

    private void Start()
    {
        enabled = false;
        Invoke(nameof(wait),3f);
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, 800f, -10f) + offset;
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition, ref velocity,smoothTime);
    }

    private void wait()
    {
        enabled = true;
    }
}
