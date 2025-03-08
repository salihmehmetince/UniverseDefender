using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class LevelFourWorker : MonoBehaviour
{
    [SerializeField]
    private Worker worker;

    private int coin;

    public string getName()
    {
        return worker.workerName;
    }

    public List<string> getQuestions()
    {
        return worker.workerQuestions;
    }

    public List<string> getAnswers()
    {
        return worker.workerAnswers;
    }

    public void act1(string answer)
    {
        transform.GetComponent<LevelFourWorkerActions>().setCoin(coin);
        transform.GetComponent<LevelFourWorkerActions>().action1(answer);
    }

    public void act2(string answer)
    {
        transform.GetComponent<LevelFourWorkerActions>().setCoin(coin);
        transform.GetComponent<LevelFourWorkerActions>().action2(answer);
    }

    public void act3(string answer)
    {
        transform.GetComponent<LevelFourWorkerActions>().setCoin(coin);
        transform.GetComponent<LevelFourWorkerActions>().action3(answer);
    }

    public void act4(string answer)
    {
        transform.GetComponent<LevelFourWorkerActions>().setCoin(coin);
        transform.GetComponent<LevelFourWorkerActions>().action4(answer);
    }

    public void setCoin(int coin)
    {
        this.coin = coin;
    }

    public Worker getWorker()
    {
        return worker;
    }
}
