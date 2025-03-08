using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LevelTwoPlayerController : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private bool IsWalking=true;

    private bool IsFlying=false;

    [SerializeField]
    private int speed = 15000;

    [SerializeField]
    private Animator playerAnimator;

    private const string finalIsWalk = "IsWalk";

    private const string finalIsFlying = "IsFly";

    private Rigidbody2D rgbody;

    private Vector3 moveDirection;

    private int health = 3;

    private const string finalDangerousRocket = "DangerousRocket";

    [SerializeField]
    private GameObject explode;

    private const string finalWheel = "Wheel";
    
    private const string finalRay = "Ray";

    [SerializeField]
    private TextMeshProUGUI healthText;

    private const string finalRocketFire = "RocketFire";

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Animator healthAnimator;

    private const string finalIsReduce = "IsReduce";

    private void Awake()
    {
        rgbody = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = gameInput.getMovementVectorNormalized();
        moveDirection = new Vector3(inputVector.x, (inputVector.y>0)?inputVector.y:0f, 0f);
        //transform.position += moveDirection * Time.deltaTime * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,310f,30750f), Mathf.Clamp(transform.position.y, 0f, 940f), transform.position.z);
        if(inputVector.x==1f)
        {
            IsWalking = true;
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if(inputVector.x==-1f)
        {
            IsWalking = true;
            transform.localScale = new Vector3(-1f,transform.localScale.y,transform.localScale.z);
        }
        else
        {
            IsWalking = false;
        }
        if (inputVector.y > 0)
        {
            IsFlying = true;
        }
        else
        {
            IsFlying = false;
        }

        if(IsWalking)
        {
            playerAnimator.SetBool(finalIsWalk, true);
        }
        else
        {
            playerAnimator.SetBool(finalIsWalk, false);
        }

        if (IsFlying)
        {
            playerAnimator.SetBool(finalIsFlying, true);
        }
        else
        {
            playerAnimator.SetBool(finalIsFlying, false);
        }
    }
    private void FixedUpdate()
    {
        rgbody.velocity = moveDirection*speed*Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == finalDangerousRocket)
        {
            gameObject.SetActive(false);
            Instantiate(explode, Camera.main.transform);
            Invoke(nameof(showGameOverScene), 1f);
        }
        else if(collision.gameObject.tag == finalWheel)
        {
            health--;
            healthAnimator.SetTrigger(finalIsReduce);
            healthText.text = "X " + health;
            Debug.Log(health);
            if(health <= 0)
            {
                gameObject.SetActive(false);
                Invoke(nameof(showGameOverScene), 1f);
            }
        }
        else if(collision.gameObject.tag == finalRay)
        {
            gameObject.SetActive(false);
            Invoke(nameof(showGameOverScene), 1f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == finalRocketFire)
        {
            gameObject.SetActive(false);
            Invoke(nameof(showGameOverScene), 1f);
        }
    }

    private void showGameOverScene()
    {
        gameOverPanel.SetActive(true);
    }

}
