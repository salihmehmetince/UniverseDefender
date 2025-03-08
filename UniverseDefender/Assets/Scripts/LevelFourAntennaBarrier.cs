using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourAntennaBarrier : MonoBehaviour
{
    private Rigidbody2D rgbody2d;

    private Vector3 firstPosition;

    private float timer = 0;

    private float timerMax = 3f;

    private float speed = 10000f;
    void Start()
    {
        rgbody2d=GetComponent<Rigidbody2D>();
        firstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            rgbody2d.velocity = new Vector2(Random.Range(-5f,5f)*speed,Random.Range(-5f,5f)*speed);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,firstPosition.x-500f,firstPosition.x+500f),Mathf.Clamp(transform.position.y, firstPosition.y- 400, firstPosition.y+800f),transform.localPosition.z);
    }
}
