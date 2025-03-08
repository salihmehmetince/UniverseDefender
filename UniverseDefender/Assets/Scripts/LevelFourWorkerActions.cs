using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourWorkerActions : MonoBehaviour
{
    private Image workerVisual;

    private GameObject speechBalloon;

    private Image speechBalloonVisual;

    private TextMeshProUGUI speechBalloonText;

    protected int coin;

    private void Start()
    {
        workerVisual = transform.GetChild(0).gameObject.GetComponent<Image>();
        speechBalloon = workerVisual.transform.GetChild(0).gameObject;
        speechBalloonVisual = speechBalloon.transform.GetChild(0).gameObject.GetComponent<Image>();
        speechBalloonText = speechBalloonVisual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }
    public virtual void action1(string answer)
    {
        Debug.Log("Worker action1");
    }

    public virtual void action2(string answer)
    {
        Debug.Log("Worker action2");

    }

    public virtual void action3(string answer)
    {
        Debug.Log("Worker action3");

    }

    public virtual void action4(string answer)
    {
        Debug.Log("Worker action4");
    }

    public void makeConversation(string message)
    {
        speechBalloonText.text = message;
        speechBalloon.SetActive(true);
        Invoke(nameof(endConversation), 2f);
    }

    public void endConversation()
    {
        speechBalloon.SetActive(false);
    }

    public void setCoin(int coin)
    {
        this.coin = coin;
    }
}
