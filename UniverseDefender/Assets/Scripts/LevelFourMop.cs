using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourMop : MonoBehaviour
{
    
    private GameInput gameInput;

    private float cleaningAmount = 0;
    private float cleaningAmountMax = 10;


    private Vector3 firstPosition;

    private Transform player;

    private bool isCleaning=false;

    private const string finalGround = "Ground";

    private const string finalIsClean = "IsClean";

    private Transform mopVisual;

    private int salary = 30;

    private float playerSpeed = 250000f;
    // Start is called before the first frame update
    void Start()
    {
       
        player = transform.parent;
        gameInput =player.GetComponent<LevelFourPlayerController2>().getGameInput();
        firstPosition =transform.position;
        mopVisual = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        handleCleaning();
        handleContraint();
    }

    private void handleCleaning()
    {
        float movementAmount = Mathf.Abs(gameInput.getMovementVectorNormalized().x);
        if (movementAmount ==0f)
        {
            isCleaning = false;
        }
        else
            isCleaning = true;
        {

        }
        if(isCleaning)
        {
            cleaningAmount += movementAmount * Time.deltaTime;
            mopVisual.GetComponent<Animator>().SetBool(finalIsClean,true);
            if(cleaningAmount>=cleaningAmountMax)
            {
                Debug.Log("temizlik bitti");
                player.GetComponent<LevelFourPlayerController2>().increaseCoinAmount(salary);
                player.GetComponent<LevelFourPlayerController2>().setSpeed(playerSpeed);
                Destroy(transform.gameObject);
            }
        }
        else
        {
            mopVisual.GetComponent<Animator>().SetBool(finalIsClean, false);
        }
    }

    private void handleContraint()
    {
        player.position = new Vector3(Mathf.Clamp(player.position.x, firstPosition.x - 4500, firstPosition.x + 2500), player.position.y, player.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalGround)
        {
            isCleaning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if (gObject.tag == finalGround)
        {
            isCleaning = false;
        }
    }
}
