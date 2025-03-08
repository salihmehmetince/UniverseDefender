using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourStoreWorkerActions : LevelFourWorkerActions
{
    [SerializeField]
    protected LevelFourStoreWorker levelFourStoreWorker;

    protected int index;

    [SerializeField]
    protected Transform player;

    protected const string finalIsWork = "IsWork";

    public override void action1(string answer)
    {
        index = 0;
        handleSellAction(index);
        Debug.Log("store worker action 1");
    }

    public override void action2(string answer)
    {
        index = 1;
        handleSellAction(index);
        Debug.Log("store worker action 2");

    }

    public override void action3(string answer)
    {
        index = 2;
        handleSellAction(index);
        Debug.Log("store worker action 3");

    }

    public override void action4(string answer)
    {
        handleWork();
        Debug.Log("store worker action 4");
    }

    protected void handleSellAction(int index)
    {
        int price = levelFourStoreWorker.getPrices()[index];

        if (coin >= price)
        {
            Transform workBench = transform.parent.GetChild(2);
            GameObject tool = workBench.GetChild(index + 1).gameObject;
            GameObject newTool = Instantiate(tool, workBench);
            newTool.GetComponent<BoxCollider2D>().enabled = true;
            GameObject stateText = newTool.transform.GetChild(1).gameObject;
            stateText.SetActive(true);
            Image newToolVisual = newTool.transform.GetChild(0).gameObject.GetComponent<Image>();
            newToolVisual.color = new Color(204f, 229f, 255f);
            player.GetComponent<LevelFourPlayerController2>().reduceCoinAmount(price);
            string positiveAnswer = levelFourStoreWorker.getTools()[index];
            makeConversation(positiveAnswer);
        }
        else
        {
            string negativeAnswer = "Para yetersiz";
            makeConversation(negativeAnswer);
        }
    }

    protected void handleWork()
    {
        GameObject producePlace = transform.parent.GetChild(3).gameObject;
        GameObject produceSlider = producePlace.transform.GetChild(1).gameObject;
        player.position = producePlace.transform.position;
        player.GetComponent<LevelFourPlayerController2>().setSpeed(0);
        player.GetChild(0).GetComponent<Animator>().enabled = false;
        producePlace.transform.GetChild(2).gameObject.SetActive(true);
        producePlace.transform.GetChild(2).GetComponent<Animator>().SetBool(finalIsWork, true);
        produceSlider.SetActive(true);
        producePlace.GetComponent<LevelFourProducePlace>().enabled = true;
        producePlace.GetComponent<LevelFourProducePlace>().setPlayerGameObject(player.gameObject);
    }
}
