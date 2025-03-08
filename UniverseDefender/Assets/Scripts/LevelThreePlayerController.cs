using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelThreePlayerController : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private Rigidbody2D rgBody;

    private Vector3 moveDirection;

    private float speed = 50000f;

    [SerializeField]
    private GameObject speechBalloon;

    private const string finalControlPoint = "ControlPoint";

    private const string finalBarrier = "Barrier";

    private int health = 5;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private Animator healthAnimator;

    private const string finalIsDecrease = "IsDecrease";

    private Animator playerAnimator;

    private const string finalIsDamage = "IsDamage";

    private const string finalHealthPiece = "HealthPiece";

    private const string finalIsIncrease = "IsIncrease";

    private string[] passWords = { "Iyi kamufle oldum","Bu seferlik sýyrýldýk","Bizi fark etmediler","Ucuz atlattýk"};

    [SerializeField]
    private GameObject gameOverScreen;

    void Start()
    {
        healthText.text = "X " + health;
        playerAnimator = GetComponent<Animator>();
        rgBody=GetComponent<Rigidbody2D>();
        enabled = false;
        Invoke(nameof(waitForAnimation), 1f);
        Invoke(nameof(waitForSpeech),1f);
        Invoke(nameof(waitForSpeechEnd), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVecor=gameInput.getMovementVectorNormalized();
        moveDirection = new Vector3(0f, inputVecor.y,0f);
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,100f,1000f),0f);
    }

    private void FixedUpdate()
    {
        rgBody.velocity = moveDirection * speed * Time.deltaTime;
    }

    private void waitForAnimation()
    {
        enabled = true;
    }

    private void waitForSpeech()
    {
        speechBalloon.SetActive(true);
    }

    private void waitForSpeechEnd()
    {
        speechBalloon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==finalBarrier)
        {
            damaged(5);
            string message = "Engellere carpma";
            handleDamageSpeech(message);
        }
        else if(collision.gameObject.tag ==finalControlPoint)
        {
            GameObject controlPointPart1 = collision.transform.GetChild(0).gameObject;
            GameObject barrier = controlPointPart1.transform.GetChild(0).gameObject;
            GameObject playerVisual = transform.GetChild(0).gameObject;
            Color playerColor = playerVisual.GetComponent<Image>().color;
            Color controlPointColor=barrier.GetComponent<Image>().color;

            if(playerColor==controlPointColor)
            {
                handlePassSpeech();
            }
            else
            {
                damaged(1);
                string message = "Dogru rengi seç";
                handleDamageSpeech(message);
                if (health<=0)
                {
                    gameOverScreen.SetActive(true);
                }
            }
        }else if(collision.gameObject.tag == finalHealthPiece)
        {
            increaseHealth(2);
            Destroy(collision.gameObject);
        }
    }

    private void damaged(int lostAmount)
    {
        health = health - lostAmount;
        healthText.text = "X " + health;
        healthAnimator.SetTrigger(finalIsDecrease);
        playerAnimator.SetTrigger(finalIsDamage);
    }

    private void increaseHealth(int gainAmount)
    {
        health += gainAmount;
        healthText.text = "X " + health;
        healthAnimator.SetTrigger(finalIsIncrease);
    }

    private void handleDamageSpeech(string message)
    {
        TextMeshProUGUI speechBalloonText = speechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = message;
        waitForSpeech();
        Invoke(nameof(waitForSpeechEnd), 2f);
    }

    private void handlePassSpeech()
    {
        TextMeshProUGUI speechBalloonText = speechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = passWords[Random.Range(0,passWords.Length-1)];
        waitForSpeech();
        Invoke(nameof(waitForSpeechEnd), 2f);
    }
}
