using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourCageBarrier : MonoBehaviour
{
    private Rigidbody2D rgbody2d;

    private float speed = 800f;

    private float timer = 0f;
    private float timerMax = 1f;

    private void Awake()
    {
        rgbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
            rgbody2d.velocity = new Vector2(1f,1f)*speed;
        }
        else if (timer >= timerMax && timer < 2 * timerMax)
        {
            timer += Time.deltaTime;
            rgbody2d.velocity = new Vector2(1f,-1f) * speed;
        }
        else if (timer >= 2 * timerMax && timer < 3 * timerMax)
        {
            timer += Time.deltaTime;
            rgbody2d.velocity = new Vector2(-1f,-1f) * speed;
        }
        else if (timer >= 3 * timerMax && timer < 4 * timerMax)
        {
            timer += Time.deltaTime;
            rgbody2d.velocity = new Vector2(-1f,1f) * speed;
        }
        else
        {
            timer = 0f;
        }
    }
}
