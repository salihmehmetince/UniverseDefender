using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourTransportVehicle : MonoBehaviour
{
    private const string finalPlayer = "Player";

    private int productAmount = 0;

    private int salary;

    [SerializeField]
    protected LevelFourWorkStationWorker levelFourWorkStationWorker;

    private string location;

    private const string finalRestaurantWorker = "RestaurantWorker";

    private const string finalStoreWorker = "StoreWorker";

    private const string finalWorkStationWorker = "WorkStationWorker";

    private bool isDelivered=false;

    private Vector3 vehicleFirstPosition;

    private Vector3 playerLastPosition;


    [SerializeField]
    private Transform playerParent;

    private void Start()
    {
        vehicleFirstPosition = transform.position;
        salary = levelFourWorkStationWorker.getSalaries()[1];
        location = levelFourWorkStationWorker.getCustomers()[Random.Range(0, levelFourWorkStationWorker.getCustomers().Count)];
        playerLastPosition=transform.parent.position;
    }

    private void Update()
    {
        if (isDelivered)
        {

            if (transform.position.x >= vehicleFirstPosition.x)
            {
                Debug.Log("teslim tamamlandý");
                transform.GetComponent<LevelFourTransportVehicleController>().enabled = false;
                transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = vehicleFirstPosition;
                GameObject player = transform.GetChild(2).gameObject;
                player.transform.SetParent(playerParent);
                player.transform.position = playerLastPosition;
                Rigidbody2D rgbody2d= player.AddComponent<Rigidbody2D>();
                player.GetComponent<LevelFourPlayerController2>().setRigidBody2D(rgbody2d);
                player.GetComponent<Rigidbody2D>().gravityScale = 650f;
                player.GetComponent<Rigidbody2D>().freezeRotation = true;
                player.transform.GetChild(0).GetComponent<Image>().enabled = true;
                player.transform.GetChild(0).GetComponent<Animator>().enabled = true;
                player.GetComponent<LevelFourPlayerController2>().enabled = true;
                isDelivered = false;
                
                int productValue = 15;
                Transform product = transform.GetChild(1);
                for (int i=0;i<product.childCount;i++)
                {
                    Destroy(product.GetChild(i).gameObject);
                }
                int salary = (product.childCount) * productValue;
                player.GetComponent<LevelFourPlayerController2>().increaseCoinAmount(salary);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gObject = collision.gameObject;
        if (gObject.tag==finalPlayer)
        {
            Transform warehouse = transform.parent.GetChild(3);
            Slider transportSlider = warehouse.GetChild(1).GetComponent<Slider>();
            GameObject player = gObject;

            if (warehouse.GetComponent<LevelFourWarehouse>().getHasProduct())
            {
                GameObject product = gObject.transform.GetChild(2).gameObject;
                
                if (productAmount < transportSlider.maxValue)
                {
                    product.transform.SetParent(transform.GetChild(1));
                    productAmount++;
                    transportSlider.value = productAmount;
                    warehouse.GetComponent<LevelFourWarehouse>().setHasProduct(false);
                }
            }
            else
            {
                if(productAmount >= transportSlider.maxValue)
                {
                    warehouse.GetComponent<BoxCollider2D>().isTrigger = true;
                    transform.GetComponent<BoxCollider2D>().isTrigger = true;
                    player.GetComponent<LevelFourPlayerController2>().increaseCoinAmount(salary * productAmount);
                    productAmount = 0;
                    transportSlider.value = productAmount;
                    transportSlider.gameObject.SetActive(false);
                }
            }
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalRestaurantWorker|| gObject.tag == finalStoreWorker)
        {
            if (gObject.GetComponent<LevelFourWorker>().getName() == location&&!isDelivered)
            {
                string message = "teslim edildi";
                makeConversation(message);
                isDelivered = true;
            }
        }
        
    }

    private void makeConversation(string message)
    {
        Transform player = transform.GetChild(2);
        Transform speechBalloon = player.GetChild(1);
        TextMeshProUGUI speechBalloonText = speechBalloon.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = message;
        speechBalloon.gameObject.SetActive(true);
        Invoke(nameof(endConversation), 2f);
    }

    private void endConversation()
    {
        Transform player = transform.GetChild(2);
        Transform speechBalloon = player.GetChild(1);
        speechBalloon.gameObject.SetActive(false);
    }
}
