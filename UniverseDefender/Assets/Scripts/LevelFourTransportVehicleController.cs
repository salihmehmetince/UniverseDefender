using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelFourTransportVehicleController : MonoBehaviour
{
    private Rigidbody2D rgbody2d;

    [SerializeField]
    private GameInput gameInput;

    
    private float speed = 850000;

    private Vector3 moveDirection;

    private float minX = 36000f;
    private float maxX = 200000f;
    private float minY = -3075f;
    private float maxY = -1200f;

    private bool isMove;

    private const string finalIsMove = "IsMove";

    private void Awake()
    {
        rgbody2d = GetComponent<Rigidbody2D>();
        transform.GetComponent<Animator>().enabled = true;
    }

    private void Update()
    {
        handleMovement();
    }

    private void FixedUpdate()
    {
        makeForceForMovement();
    }

    private void handleMovement()
    {
        Vector2 inputVector = gameInput.getMovementVectorNormalized();
        moveDirection = new Vector3(inputVector.x, (inputVector.y > 0) ? inputVector.y : 0f, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        if (inputVector.x == 1f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            isMove = true;
        }
        else if (inputVector.x == -1f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            isMove = true;

        }
        else if (inputVector.x > 0.5f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            isMove = true;

        }
        else if (inputVector.x < -0.5f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            isMove = true;

        }
        else
        {
            isMove = false;

        }

        transform.GetComponent<Animator>().SetBool(finalIsMove,isMove);
        Debug.Log(isMove);

    }

    private void makeForceForMovement()
    {
        rgbody2d.velocity = moveDirection * speed * Time.deltaTime;
    }
}
