using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourPlayerController2 : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    [SerializeField]
    private float speed=3500;

    private bool isWalking;

    private bool isFlying;

    [SerializeField]
    private Animator playerAnimator;

    private const string finalIsFlying="IsFlying";

    private const string finalIsWalking = "IsWalking";

    private Rigidbody2D rgbody2d;

    private Vector3 moveDirection;

    private const string finalCoin = "Coin";

    private int coin;

    [SerializeField]
    private TextMeshProUGUI coinText;

    private const string finalRestaurantWorker = "RestaurantWorker";

    private bool isTalk = false;

    private GameObject worker;

    private Image workerVisual;

    private GameObject speechBalloon;

    private GameObject bigSpeechBalloon;

    private Image speechBalloonVisual;

    private Image bigSpeechBalloonVisual;

    private TextMeshProUGUI speechBalloonText;

    private TextMeshProUGUI bigSpeechBalloonText;

    private List<string> questions;

    private string workerName;

    private List<string> answers;


    private bool isChoose = false;

    private const string finalMineral = "Mineral";

    private int foodAmount;

    [SerializeField]
    private Slider foodSlider;

    private const string finalStoreWorker = "StoreWorker";

    [SerializeField]
    private Animator coinAnimator;

    private const string finalIsIncrease = "IsIncrease";

    private float minX = 32000f;
    private float maxX = 200000f;
    private float minY = -3075f;
    private float maxY =-1200f;

    private const string finalWorkStationWorker = "WorkStationWorker";

    private const string finalPlayer = "Player";

    private const string finalIsPassToNextLevel = "IsPassToNextLevel";


    [SerializeField]
    private Slider piecesSlider;

    [SerializeField]
    private Transform rocket;


    private void Awake()
    {
        rgbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gameInput.onTalk += gameInputOnTalk;
        gameInput.onChoose += gameInputOnChoose;
    }

    private void gameInputOnChoose(object sender, EventArgs e)
    {
        handleChoose();
    }

    private void gameInputOnTalk(object sender, EventArgs e)
    {
        talkWithWorker();
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
        moveDirection = new Vector3(inputVector.x,(inputVector.y>0)?inputVector.y:0f,0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),Mathf.Clamp(transform.position.y,minY,maxY),transform.position.z);
        if(inputVector.x==1f)
        {
            isWalking = true;
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if(inputVector.x==-1f)
        {
            isWalking = true;
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        else if(inputVector.x>0.5f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);

        }
        else if(inputVector.x<-0.5f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);

        }
        else
        {
            isWalking = false;
        }

        if(inputVector.y>=0f)
        {
            isFlying = true;
        }
        else
        {
            isFlying = false;
        }

        if(isWalking)
        {
            playerAnimator.SetBool(finalIsWalking,true);
        }
        else
        {
            playerAnimator.SetBool(finalIsWalking,false);
        }

        if(isFlying)
        {
            playerAnimator.SetBool(finalIsFlying,false);
        }
        else
        {
            playerAnimator.SetBool(finalIsFlying, false);
        }
    }

    private void makeForceForMovement()
    {
        if(rgbody2d!=null)
        {
            rgbody2d.velocity = moveDirection * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalCoin)
        {
            increaseCoinAmount(gObject);
        }
        else if(gObject.tag== finalRestaurantWorker)
        {
            recogniseRestaurantWorker(gObject);
        }
        else if(gObject.tag==finalStoreWorker)
        {
            recogniseStoreWorker(gObject);
        }
        else if (gObject.tag == finalWorkStationWorker)
        {
            recogniseWorkStationWorker(gObject);
        }
        else if(gObject.tag == finalMineral)
        {
            Destroy(gObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if (gObject.tag == finalRestaurantWorker)
        {
            forgetRestaurantWorker();
        }
        else if(gObject.tag == finalStoreWorker)
        {
            forgetStoreWorker();
        }
        else if (gObject.tag == finalWorkStationWorker)
        {
            forgetWorkStationWorker();
        }
    }

    private void increaseCoinAmount(GameObject coinObj)
    {
        Destroy(coinObj);
        coin++;
        coinText.text = "X " + coin;
    }

    private void recogniseRestaurantWorker(GameObject restaurantWorker)
    {
        worker = restaurantWorker;
        findObjects();
        workerVisual.color = Color.magenta;
        speechBalloonText.text = "merhaba";
        speechBalloon.SetActive(true);
        isTalk = true;
    }

    private void recogniseStoreWorker(GameObject restaurantWorker)
    {
        worker = restaurantWorker;
        findObjects();
        workerVisual.color =new Color(255f, 175f, 0f);
        speechBalloonText.text = "merhaba";
        speechBalloon.SetActive(true);
        isTalk = true;
    }

    private void recogniseWorkStationWorker(GameObject workStationWorker)
    {
        worker = workStationWorker;
        findObjects();
        workerVisual.color = new Color(255f, 255f, 153f);
        speechBalloonText.text = "merhaba";
        speechBalloon.SetActive(true);
        isTalk = true;
    }

    private void forgetRestaurantWorker()
    {
        workerVisual.color = Color.white;
        speechBalloon.SetActive(false);
        isTalk = false;
        worker = null;
        bigSpeechBalloon.SetActive(false);
        isChoose = false;
    }

    private void forgetStoreWorker()
    {
        workerVisual.color = Color.white;
        speechBalloon.SetActive(false);
        isTalk = false;
        worker = null;
        bigSpeechBalloon.SetActive(false);
        isChoose = false;
    }

    private void forgetWorkStationWorker()
    {
        workerVisual.color = Color.white;
        speechBalloon.SetActive(false);
        isTalk = false;
        worker = null;
        bigSpeechBalloon.SetActive(false);
        isChoose = false;
    }

    private void talkWithWorker()
    {
        if(isTalk)
        {
                speechBalloon.SetActive(false);
                bigSpeechBalloon.SetActive(true);
                bigSpeechBalloonText.text = "merhaba benim adým " + workerName + "\n";
                for(int i=0; i<questions.Count;i++)
                {
                    bigSpeechBalloonText.text += questions[i] + "\n";
                }
                isChoose = true;
        }
    }

    private void handleChoose()
    {
        if(isChoose)
        {
            bigSpeechBalloon.SetActive(false);
            string answer;
            int chooseValue = gameInput.getChooseValue();
            if(chooseValue==1)
            {
                answer = answers[0];
                worker.GetComponent<LevelFourWorker>().setCoin(coin);
                worker.GetComponent<LevelFourWorker>().act1(answer);
            }
            else if(chooseValue==2)
            {
                answer = answers[1];
                worker.GetComponent<LevelFourWorker>().setCoin(coin);
                worker.GetComponent<LevelFourWorker>().act2(answer);
            }
            else if (chooseValue == 3)
            {
                answer = answers[2];
                worker.GetComponent<LevelFourWorker>().setCoin(coin);
                worker.GetComponent<LevelFourWorker>().act3(answer);
            }
            else if (chooseValue == 4)
            {
                answer = answers[3];
                worker.GetComponent<LevelFourWorker>().setCoin(coin);
                worker.GetComponent<LevelFourWorker>().act4(answer);
            }
            else
            {
                answer = "";
                Debug.Log(answer);
            }

        }
    }

    private void findObjects()
    {
        if(worker!=null)
        {
            workerVisual = worker.transform.GetChild(0).gameObject.GetComponent<Image>();
            speechBalloon = workerVisual.transform.GetChild(0).gameObject;
            bigSpeechBalloon = workerVisual.transform.GetChild(1).gameObject;
            speechBalloonVisual = speechBalloon.transform.GetChild(0).gameObject.GetComponent<Image>();
            bigSpeechBalloonVisual = bigSpeechBalloon.transform.GetChild(0).gameObject.GetComponent<Image>();
            speechBalloonText = speechBalloonVisual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            bigSpeechBalloonText = bigSpeechBalloonVisual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            questions = worker.GetComponent<LevelFourWorker>().getQuestions();
            workerName = worker.GetComponent<LevelFourWorker>().getName();
            answers = worker.GetComponent<LevelFourWorker>().getAnswers();
        }
    }

    public void reduceCoinAmount(int amount)
    {
        coin -= amount;
        coinText.text = "X " + coin;
    }

    public void increaseCoinAmount(int amount)
    {
        coin += amount;
        coinText.text = "X " + coin;
        coinAnimator.SetTrigger(finalIsIncrease);
    }

    public void increaseFood()
    {
        foodAmount++;
        foodSlider.value = foodAmount;
    }

    public void setSpeed(float speed)
    {
        if(speed<0)
        {
            this.speed = 0f;
        }
        else
        {
            this.speed = speed;
        }
    }

    public void setRigidBody2D(Rigidbody2D rgbody2d)
    {
        this.rgbody2d = rgbody2d;
    }

    public GameInput getGameInput()
    {
        return gameInput;
    }

    private void makeConversation(GameObject player,string message)
    {
        Transform playerVisual = player.transform.GetChild(0);
        speechBalloon = playerVisual.GetChild(0).gameObject;
        TextMeshProUGUI speechBalloonText = speechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = message;
        speechBalloon.SetActive(true);
        Invoke(nameof(endConversation), 2f);
    }

    private void endConversation()
    {
        speechBalloon.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gObject = collision.gameObject;
        if (gObject.tag == finalPlayer)
        {
            if (foodSlider.value >= foodSlider.maxValue && piecesSlider.value >= piecesSlider.maxValue)
            {
                transform.GetChild(0).SetParent(rocket);
                string message = "Yola devam";
                Transform playerVisual = rocket.GetChild(1);
                speechBalloon = playerVisual.GetChild(0).gameObject;
                TextMeshProUGUI speechBalloonText = speechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                speechBalloonText.text = message;
                speechBalloon.SetActive(true);
                Invoke(nameof(endConversation), 2f);
                rocket.GetChild(1).gameObject.SetActive(false);
                rocket.GetComponent<Animator>().enabled = true;
                rocket.GetComponent<Animator>().SetTrigger(finalIsPassToNextLevel);
                enabled = false;

            }
            else
            {
                string message = "Henüz gidemem hazýr deðilim";
                makeConversation(transform.gameObject,message);
            }
        }
    }
}
