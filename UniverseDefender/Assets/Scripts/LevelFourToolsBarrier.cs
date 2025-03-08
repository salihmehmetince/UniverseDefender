using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourToolsBarrier : MonoBehaviour
{

    private Rigidbody2D rgbody2d;

    private float timer = 0f;

    private float timerMax = 5f;

    private float speed = 8000f;

    private void Awake()
    {
        rgbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            speed = Random.Range(8000f,20000f);
            timer = 0;
            rgbody2d.velocity = new Vector2(0f, Random.Range(-5f, 5f))*speed;
        }

        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,200f,1450f),0f);
    }
}
