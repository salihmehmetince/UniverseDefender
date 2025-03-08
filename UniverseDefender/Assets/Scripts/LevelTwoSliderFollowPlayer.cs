using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSliderFollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(-500f, 270f, 10f);
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = Camera.main.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
