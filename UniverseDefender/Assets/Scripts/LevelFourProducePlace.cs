using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourProducePlace : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private int workAmount = 0;

    private const float finalSpeed = 250000f;

    private GameObject playerGameObject;

    private int salary=5;

    private const string finalIsWork = "IsWork";

    private void Start()
    {
        gameInput.onWork += gameInputOnWork;
    }

    private void gameInputOnWork(object sender, EventArgs e)
    {
        if(playerGameObject!=null)
        {
            Slider produceSlider = transform.GetChild(1).GetComponent<Slider>();
            if (workAmount < produceSlider.maxValue)
            {
                workAmount++;
                produceSlider.value = workAmount;
            }
            else
            {
                workAmount = 0;
                produceSlider.value = workAmount;
                produceSlider.gameObject.SetActive(false);
                produceSlider.transform.parent.GetChild(2).GetComponent<Animator>().SetBool(finalIsWork,false);
                produceSlider.transform.parent.GetChild(2).gameObject.SetActive(false);
                playerGameObject.GetComponent<LevelFourPlayerController2>().setSpeed(finalSpeed);
                playerGameObject.transform.GetChild(0).GetComponent<Animator>().enabled = true;
                playerGameObject.GetComponent<LevelFourPlayerController2>().increaseCoinAmount(salary);
                playerGameObject = null;
            }
        }

    }

    public void setPlayerGameObject(GameObject gameObject)
    {
        this.playerGameObject = gameObject;
    }
    
}
