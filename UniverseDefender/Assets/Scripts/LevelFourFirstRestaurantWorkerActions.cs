using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourFirstRestaurantWorkerActions : LevelFourRestaurantWorkerActions
{
    [SerializeField]
    private Transform minerals;
    public override void action1(string answer)
    {
        makeConversation(answer);
    }

    public override void action2(string answer)
    {
        makeConversation(answer);
    }

    public override void action3(string answer)
    {
        handleFind(answer);
    }

    public override void action4(string answer)
    {
        int index = 0;
        int price = levelFourRestaurantWorker.getPrices()[index];
        if(coin>=price)
        {
            if(tables.Count>0)
            {
                restaurantWorkerAnimator = transform.GetComponent<Animator>();
                Transform workerVisual = transform.GetChild(0);
                food = workerVisual.GetChild(2).gameObject;
                meal = food.transform.GetChild(2).GetComponent<Image>();
                meal.sprite = levelFourRestaurantWorker.getFoodSprites()[index];
                restaurantWorkerAnimator.SetTrigger(finalIsTable + tables[0]);
                string positiveAnswer = levelFourRestaurantWorker.getFoods()[index];
                makeConversation(positiveAnswer);
                player.GetComponent<LevelFourPlayerController2>().reduceCoinAmount(price);
                tables.RemoveAt(0);
            }
            else
            {
                string negativeAnswer = "Tüm masalar dolu";
                makeConversation(negativeAnswer);
            }
        }
        else
        {
            string negativeAnswer = "Para yetersiz";
            makeConversation(negativeAnswer);
        }
    }

    private void givePresent()
    {
        int index = 0;
        restaurantWorkerAnimator = transform.GetComponent<Animator>();
        Transform workerVisual = transform.GetChild(0);
        food = workerVisual.GetChild(2).gameObject;
        meal = food.transform.GetChild(2).GetComponent<Image>();
        meal.sprite = levelFourRestaurantWorker.getFoodSprites()[index];
        restaurantWorkerAnimator.SetTrigger(finalIsTable + tables[0]);
        string positiveAnswer = levelFourRestaurantWorker.getFoods()[index];
        makeConversation(positiveAnswer);
        tables.RemoveAt(0);
    }

    private void presentSpeech()
    {
        string message = "Lütfen sana bir yemek ýsmarlamama izin ver";
        makeConversation(message);
    }

    private void handleFind(string answer)
    {
        if (minerals.childCount <= 0)
        {
            makeConversation(answer);
            Invoke(nameof(givePresent), 2f);
            Invoke(nameof(presentSpeech), 6f);
        }
        else
        {
            string negativeAnswer = "Hepsi bu kadar deðildi\nLütfen hepsini bulabilir misin";
            makeConversation(negativeAnswer);
        }
    }
}
