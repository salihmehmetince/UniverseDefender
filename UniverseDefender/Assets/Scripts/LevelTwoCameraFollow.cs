using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LevelTwoCameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;

    private Vector3 origin = new Vector3(400f,250f);

    private void Start()
    {
        Invoke(nameof(wait), 1.5f);
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 4.5f, -10f) + offset+origin;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void wait()
    {

    }
}
