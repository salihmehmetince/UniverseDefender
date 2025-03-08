using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelTwoCharacter1Speech : MonoBehaviour
{
    private const string finalPlayer = "Player";

    [SerializeField]
    private GameInput gameInput;

    private bool isTalk=false;

    private TextMeshProUGUI speechBalloonText;

    private GameObject speechBalloon;
    private void Start()
    {
        gameInput.onTalk += gameInputOnTalk;
        speechBalloon = transform.GetChild(1).gameObject;
        speechBalloonText = transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void gameInputOnTalk(object sender, EventArgs e)
    {
        if(isTalk)
        {
            speechBalloon.SetActive(true);
            speechBalloonText.text = "Yakýta ihtiyacýn olduðunu görüyorum";
            Invoke(nameof(secondText),2f);
            Invoke(nameof(thirdText), 4f);
            Invoke(nameof(finishConversation),6f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag ==finalPlayer)
        {
            isTalk=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTalk = false;
    }

    private void secondText()
    {
        speechBalloonText.text = "Ama buralarda dikkatli olmalýsýn";
    }

    private void thirdText()
    {
        speechBalloonText.text = "Bazý sistemler hasarlý";
    }
    private void finishConversation()
    {
        speechBalloon.SetActive(false);
    }
}
