using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeControlPointsMove : MonoBehaviour
{
    private Animator controlPointAnimatorController;

    private const string finalIsGoTop = "IsGoTop";

    private const string finalIsGoDown = "IsGoDown";

    private float randomValue;

    private float timer = 0f;

    private float timerMax = 2f;

    private Rigidbody2D rgbody2d;

    private float speed = 10f;

    private float acceleration = 0;
    private void Start()
    {
        controlPointAnimatorController = GetComponent<Animator>();
        rgbody2d = GetComponent<Rigidbody2D>();
        acceleration = Random.Range(5, 20);
    }
    private void Update()
    {
        rgbody2d.velocity = new Vector2(-speed, 0f);
        if(timer<timerMax)
        {
            timer+=Time.deltaTime;
        }
        else
        {
            handleMove();
            timer = 0f;
            speed += acceleration;
        }
    }


    private void goBetweenOriginAndTop()
    {
        controlPointAnimatorController.SetTrigger(finalIsGoTop);
    }

    private void goBetweenOriginAndBottom()
    {
        controlPointAnimatorController.SetTrigger(finalIsGoDown);
    }

    private void handleMove()
    {
        randomValue= Random.Range(0f, 1f);
        if (randomValue < 0.5f)
        {
            goBetweenOriginAndTop();
        }
        else
        {
            goBetweenOriginAndBottom();
        }
    }


}
