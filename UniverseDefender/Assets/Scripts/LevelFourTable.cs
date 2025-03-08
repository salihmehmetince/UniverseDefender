using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourTable : MonoBehaviour
{
    private const string finalRestaurantWorker = "RestaurantWorker";

    private Transform topPoint;

    private const string finalPlayer = "Player";

    private GameObject retaurantWorker;

    private void Start()
    {
        topPoint = transform.GetChild(1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalRestaurantWorker)
        {
            if (topPoint.childCount <=0)
            {
                retaurantWorker = gObject;
                Transform workerVisual = collision.gameObject.transform.GetChild(0);
                GameObject food = workerVisual.GetChild(2).gameObject;
                Instantiate(food, topPoint);
            }
        }
        else if(gObject.tag==finalPlayer)
        {
            if(topPoint.childCount>0)
            {
                gObject.GetComponent<LevelFourPlayerController2>().increaseFood();
                Destroy(topPoint.GetChild(0).gameObject);
                int index = Convert.ToInt16(transform.parent.name[transform.parent.name.Length-1].ToString()) +1;
                retaurantWorker.GetComponent<LevelFourRestaurantWorkerActions>().clearTable(index);            
            }
        }
    }
}
