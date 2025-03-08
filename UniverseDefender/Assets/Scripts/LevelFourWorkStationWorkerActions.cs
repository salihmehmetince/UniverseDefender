using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourWorkStationWorkerActions : LevelFourWorkerActions
{

    [SerializeField]
    protected Transform player;

    private const string finalIsWork = "IsWork";

    [SerializeField]
    private GameObject mopPrefab;

    private float cleaningSpeed = 50000f;
    public override void action1(string answer)
    {
        handleProduceTool();
        Debug.Log("work station worker action 1");
    }

    public override void action2(string answer)
    {
        handleTransportProduct();
        Debug.Log("work station worker action 2");
    }

    public override void action3(string answer)
    {
        handleDeliverProducts();
        Debug.Log("work station worker action 3");

    }

    public override void action4(string answer)
    {
        handleCleaning();
        Debug.Log("work station worker action 4");
    }

    private void handleProduceTool()
    {
        GameObject producePlace = transform.parent.GetChild(2).gameObject;
        GameObject produceSlider = producePlace.transform.GetChild(1).gameObject;
        player.position = producePlace.transform.position;
        player.GetComponent<LevelFourPlayerController2>().setSpeed(0);
        player.GetChild(0).GetComponent<Animator>().enabled = false;
        producePlace.transform.GetChild(2).gameObject.SetActive(true);
        producePlace.transform.GetChild(2).GetComponent<Animator>().SetBool(finalIsWork, true);
        produceSlider.SetActive(true);
        producePlace.GetComponent<LevelFourWorkPlace>().enabled = true;
        producePlace.GetComponent<LevelFourWorkPlace>().setPlayerGameObject(player.gameObject);
    }

    private void handleTransportProduct()
    {
        GameObject warehouse = transform.parent.GetChild(3).gameObject;
        GameObject transformVehicle = transform.parent.GetChild(4).gameObject;
        GameObject transportSlider = warehouse.transform.GetChild(1).gameObject;
        Vector3 middleAddition = new Vector3(1200f,0f,0f);
        player.position = warehouse.transform.position+middleAddition;
        transportSlider.SetActive(true);
        warehouse.GetComponent<BoxCollider2D>().isTrigger = false;
        transformVehicle.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void handleDeliverProducts()
    {
        GameObject warehouse = transform.parent.GetChild(3).gameObject;
        GameObject transportVehicle = transform.parent.GetChild(4).gameObject;
        Transform products = transportVehicle.transform.GetChild(1);
        if(products.childCount<=0)
        {
            string message = "Araç boþ aracý doldurmalýsýn";
            makeConversation(message);
        }
        else
        {
            player.SetParent(transportVehicle.transform, false);
            player.localPosition = Vector3.zero;
            player.GetChild(0).GetComponent<Image>().enabled=false;
            player.GetComponent<LevelFourPlayerController2>().enabled = false;
            player.GetChild(0).GetComponent<Animator>().enabled = false;
            transportVehicle.GetComponent<Animator>().enabled = false;
            transportVehicle.GetComponent<LevelFourTransportVehicleController>().enabled = true;
            Destroy(player.GetComponent<Rigidbody2D>());
        }
        
    }

    private void handleCleaning()
    {
        GameObject warehouse = transform.parent.GetChild(3).gameObject;
        Vector3 middleAddition = new Vector3(200f, 0f, 0f);
        player.position = warehouse.transform.position + middleAddition;
        player.GetComponent<LevelFourPlayerController2>().setSpeed(cleaningSpeed);
        GameObject mop = Instantiate(mopPrefab, player);
    }
}
