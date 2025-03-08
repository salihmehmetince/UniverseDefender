using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelFourRestaurantWorkerActions : LevelFourWorkerActions
{

    [SerializeField]
    protected Transform player;

    [SerializeField]
    protected LevelFourRestaurantWorker levelFourRestaurantWorker;

    protected GameObject food;

    protected Image meal;

    private int index;

    protected Animator restaurantWorkerAnimator;

    protected const string finalIsTable = "IsTable";

    protected List<int> tables = new List<int> { 1, 2, 3, 4 };

    public override void action1(string answer)
    {
        index = 0;
        handleAction(index);
    }

    public override void action2(string answer)
    {
        index = 1;
        handleAction(index);
    }

    public override void action3(string answer)
    {
        index = 2;
        handleAction(index);
    }

    public override void action4(string answer)
    {
        index = 3;
        handleAction(index);
    }

    public void clearTable(int index)
    {
        tables.Add(index);
        tables.Sort();
    }

    private void handleAction(int index)
    {
        int price = levelFourRestaurantWorker.getPrices()[index];
        if (coin >= price)
        {
            if (tables.Count > 0)
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
}
