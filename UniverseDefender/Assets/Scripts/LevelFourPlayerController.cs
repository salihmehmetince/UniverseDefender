using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LevelFourPlayerController : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private Rigidbody2D rgbody2d;

    private bool IsGoing = false;

    private Vector3 moveDirection;

    private float speed = 80000f;

    private Animator playerAnimator;

    private const string finalEmptyJerryCan = "EmptyJerryCan";

    private int health = 10;

    private const string finalSpaceGarbage = "SpaceGarbage";

    [SerializeField]
    private GameObject garbages;

    private bool canGo = false;

    private const string finalPassControl = "PassControl";

    private float maxBorderX = 35000f;

    private float minBorderX = 1500f;

    private float maxBorderY = 1500f;

    private float minBorderY = 100f;

    private GameObject speechBalloon;

    private const string finalFirstSpaceGarbage = "FirstSpaceGarbage";

    private int maxSpacegarbageAmount;

    private const string finalIsFire = "IsFire";

    [SerializeField]
    private Animator fireAnimator;

    [SerializeField]
    private Animator rocketAnimator;

    private const string finalIsDamaged = "IsDamaged";

    private const string finalToolsBarrier = "ToolsBarrier";

    private const string finalAntennaBarrier = "AntennaBarrier";
    
    private const string finalCageBarrier = "CageBarrier";
    
    private const string finalWheelBarrier = "WheelBarrier";

    private const string finalBarrier = "Barrier";

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private Animator explosionAnimator;

    private const string finalIsExplode = "IsExplode";

    private const string finalIsPass = "IsPass";

    [SerializeField]
    private Transform player2;

    [SerializeField]
    private GameObject foodBar;

    [SerializeField]
    private GameObject PiecesBar;

    [SerializeField]
    private GameObject coinBar;
    private void Awake()
    {
        rgbody2d=GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        speechBalloon = transform.GetChild(2).gameObject;
    }

    void Start()
    {
        enabled = false;
        Invoke(nameof(waitForAnimation), 3f);
        maxSpacegarbageAmount = garbages.transform.childCount;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inpurVector=handleMovement();
        handleRotation(inpurVector);
    }

    private void FixedUpdate()
    {
        rgbody2d.velocity = moveDirection * speed * Time.deltaTime;
    }

    private void waitForAnimation()
    {
        playerAnimator.enabled = false;
        enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == finalEmptyJerryCan)
        {
            Destroy(collision.gameObject);
            string message = "Zararlý atýk";
            makeConversation(message);
            reduceHealth(2);
            
        }
        else if(collision.gameObject.tag==finalSpaceGarbage)
        {
            Destroy(collision.gameObject);
            /*if(garbages.transform.childCount-1<=0)
            {
                canGo = true;
            }*/

            if (garbages.transform.childCount -30 <= 0)
            {
                canGo = true;
            }

            if (maxSpacegarbageAmount-( garbages.transform.childCount -1)==1)
            {
                string message = "Bu copler de nerden geldi";
                makeConversation(message);
            }
            else
            {
                makeASpeechForgarbage();
            }
        }
        else if(collision.gameObject.tag==finalPassControl)
        {
            if(canGo)
            {
                passToNextPart();
            }
            else
            {
                string message = "Henuz coplerý toplamadan gidemem";
                makeConversation(message);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==finalToolsBarrier)
        {
            reduceHealth(4);
            string message = "Gemi hasar aldý";
            makeConversation(message);
        }
        else if (collision.gameObject.tag == finalAntennaBarrier)
        {
            reduceHealth(2);
            string message = "Gemi hasar aldý";
            makeConversation(message);
        }
        else if (collision.gameObject.tag == finalCageBarrier)
        {
            reduceHealth(3);
            string message = "Gemi hasar aldý";
            makeConversation(message);
        }
        else if (collision.gameObject.tag == finalWheelBarrier)
        {
            reduceHealth(3);
            string message = "Gemi hasar aldý";
            makeConversation(message);
        }
        else if(collision.gameObject.tag == finalBarrier)
        {
            reduceHealth(1);
            string message = "Bariyerlere çarpma";
            makeConversation(message);
        }
    }

    private void makeConversation(string message)
    {
        TextMeshProUGUI speechBalloonText = speechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = message;
        speechBalloon.SetActive(true);
        Invoke(nameof(endConversation), 2f);
    }

    private void endConversation()
    {
        speechBalloon.SetActive(false);
    }

    private void reduceHealth(int amount)
    {
        health -= amount;
        rocketAnimator.SetTrigger(finalIsDamaged);
        healthText.text = "X " + health;
        healthText.GetComponent<Animator>().SetTrigger(finalIsDamaged);
        if(health<=0)
        {
            handleExplosion();
        }
        Debug.Log(health);
    }
    private void makeASpeechForgarbage()
    {
        float randomNumber = Random.Range(0f,1f);

        string[] conversations = {"Kim attý bu çöpleri","her yer çok pis","Þu çöpleri temizleyelim" };

        if(randomNumber>0.7f)
        {
            string message = conversations[Random.Range(0, conversations.Length )];
            makeConversation(message);
        }
        else
        {

        }
    }

    private Vector2 handleMovement()
    {
        Vector2 inputVector = gameInput.getMovementVectorNormalized();
        moveDirection = new Vector3(inputVector.x, inputVector.y, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBorderX, maxBorderX), Mathf.Clamp(transform.position.y, minBorderY, maxBorderY), transform.position.z);
        return inputVector;
    }

    private void handleRotation(Vector2 inpurVector)
    {
        if (inpurVector != Vector2.zero)
        {
            IsGoing = true;
        }
        else
        {
            IsGoing = false;
        }

        if (IsGoing)
        {
            fireAnimator.SetBool(finalIsFire, true);
        }
        else
        {
            fireAnimator.SetBool(finalIsFire, false);
        }

        float degrees = 0f;

        if (moveDirection.y == 1f && moveDirection.x == 0f)
        {
            degrees = 90;
        }
        else if (moveDirection.y == -1f && moveDirection.x == 0f)
        {
            degrees = -90;
        }
        else if (moveDirection.y == 0f && moveDirection.x == 1f)
        {
            degrees = 0f;
        }
        else if (moveDirection.y == 0f && moveDirection.x == -1f)
        {
            degrees = -180f;

        }
        else if ((moveDirection.y < 1f && moveDirection.y > 0.5f) && (moveDirection.x < 1f && moveDirection.x > 0.5f))
        {
            degrees = 45f;

        }
        else if ((moveDirection.x > -1f && moveDirection.x < -0.5f) && (moveDirection.y < 1f && moveDirection.y > 0.5f))
        {
            degrees = 135;
        }
        else if ((moveDirection.y > -1f && moveDirection.y < -0.5f) && (moveDirection.x > -1f && moveDirection.x < -0.5f))
        {
            degrees = 225;
        }
        else if ((moveDirection.y > -1f && moveDirection.y < -0.5f) && (moveDirection.x < 1f && moveDirection.x > 0.5f))
        {
            degrees = -45f;
        }
        else
        {
            degrees = 0f;
        }

        transform.eulerAngles = Vector3.forward * degrees;
    }

    private void handleExplosion()
    {
        explosionAnimator.SetTrigger(finalIsExplode);
        Invoke(nameof(waitForExplode),1.5f);
    }

    private void waitForExplode()
    {
        gameOverScreen.SetActive(true);
    }

    private void waitForPassAnimation()
    {
        foodBar.SetActive(true);
        PiecesBar.SetActive(true);
        coinBar.SetActive(true);

        healthText.transform.parent.gameObject.SetActive(false);
        playerAnimator.enabled = false;
        transform.GetChild(1).rotation = new Quaternion(0f, 0f, 0f, 0f);
        GameObject characterVisual = transform.GetChild(0).gameObject;
        characterVisual.transform.SetParent(player2);
        speechBalloon.transform.SetParent(player2);
        speechBalloon.transform.localPosition = new Vector3(0f, 300f, 0f);
        characterVisual.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        characterVisual.transform.localPosition = new Vector3(0f,0f,0f);
        float width = 300;
        float height = 300f;
        characterVisual.GetComponent<RectTransform>().sizeDelta = new Vector2(width,height);
        string message = "Yemek beni bekle";
        makeConversation(message);
        Camera.main.GetComponent<LevelFourCameraFollow2>().enabled = true;
        enabled = false;
    }

    private void passToNextPart()
    {
        maxBorderX = 60000f;
        minBorderY = -10000f;
        playerAnimator.enabled = true;
        Camera.main.GetComponent<LevelFourCameraFollow>().enabled = false;
        playerAnimator.SetTrigger(finalIsPass);
        Invoke(nameof(waitForPassAnimation), 1f);
    }
}
