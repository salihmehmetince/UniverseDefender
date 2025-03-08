using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelFourOilCan : MonoBehaviour
{
    private bool canTake = false;

    private const string finalPlayer = "Player";

    private const string finalBrokenProducePlace = "BrokenProducePlace";

    private bool canReturn = false;

    private float workerPositionX;

    private const string finalStoreWorker = "StoreWorker";

    private Vector3 firstPosition;

    private GameObject player;
    private void Start()
    {
        workerPositionX = transform.parent.GetChild(1).position.x;
        firstPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalPlayer)
        {
            player = gObject;
            if (canTake)
            {
                transform.SetParent(player.transform,false);
                transform.localPosition = new Vector3(150f, 0f, 0f);
            }
        }
        else if(gObject.tag==finalBrokenProducePlace&&!canReturn)
        {
            gObject.transform.parent.GetChild(1).GetComponent<LevelFourThirdStoreWorkerActions>().setIsWorkPlaceBroken(false);
            canReturn = true;
            string playerMessage = "Tekerleði onardým";
            playerSpeech(player.transform, playerMessage);
            string workerMessage = "Çok teþekkürler";
            gObject.transform.parent.GetChild(1).GetComponent<LevelFourThirdStoreWorkerActions>().makeConversation(workerMessage);
        }
        else if(gObject.tag==finalStoreWorker&&(transform.position.x>=workerPositionX-100) &&canReturn)
        {
            string playerMessage = "Yað kutusu için teþekkürler";
            playerSpeech(player.transform, playerMessage);
            transform.SetParent(gObject.transform.parent,false);
            transform.position = firstPosition;
            string workerMessage = "önemli deðil";
            transform.parent.GetChild(1).GetComponent<LevelFourFourthStoreWorkerActions>().makeConversation(workerMessage);
        }
    }

    public void setCanTake(bool canTake)
    {
        this.canTake = canTake;
    }

    private void playerSpeech(Transform player,string message)
    {
        Transform speechBalloon = player.GetChild(1);
        TextMeshProUGUI speechBalloonText = speechBalloon.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = message;
        speechBalloon.gameObject.SetActive(true);
        Invoke(nameof(endConversation), 2f);
    }

    private void endConversation()
    {
        Transform speechBalloon = player.transform.GetChild(1);
        speechBalloon.gameObject.SetActive(false);
    }
}
