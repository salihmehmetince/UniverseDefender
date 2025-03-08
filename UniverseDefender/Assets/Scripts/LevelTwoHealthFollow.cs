using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoHealthFollow : MonoBehaviour
{
    private Vector3 offset= new Vector3(550f, 300f, 10f);

    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Camera.main.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothTime);
    }
}
