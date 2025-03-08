using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTwoCharacter2Speech : MonoBehaviour
{
    private const string finalPlayer = "Player";

    [SerializeField]
    private GameInput gameInput;

    private bool isTalk = false;

    private TextMeshProUGUI speechBalloonText;

    private GameObject speechBalloon;

    [SerializeField]
    private GameObject playerSpeechBalloon;

    [SerializeField]
    private GameObject lastJerryCan;

    [SerializeField]
    private RectTransform jerryCans;

    private bool didMeet=false;
    private void Start()
    {
        gameInput.onTalk += gameInputOnTalk;
        speechBalloon = transform.GetChild(1).gameObject;
        speechBalloonText = transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void gameInputOnTalk(object sender, EventArgs e)
    {
        if (isTalk)
        {
            speechBalloon.SetActive(true);
            speechBalloonText.text = "Arkadaþýmdan duyduðuma göre yakýta ihtiyacýn varmýþ";
            Invoke(nameof(secondText), 2f);
            Invoke(nameof(thirdText), 4f);
            Invoke(nameof(playerTalk),6f);
            isTalk = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == finalPlayer)
        {
            if(!didMeet)
            {
                isTalk = true;
                didMeet = true;
            }
        }
    }

    private void secondText()
    {
        speechBalloonText.text = "Sanýrým bu kadarý yeterli olmalý";
    }

    private void thirdText()
    {
        speechBalloonText.text = "Ama biraz yedekten zarar çýkmaz";
    }

    private void playerTalk()
    {
        playerSpeechBalloon.SetActive(true);
        TextMeshProUGUI playerSpeechText=playerSpeechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        playerSpeechText.text = "Teþekkürler";
        Invoke(nameof(finishConversation), 2f);
    }

    private void finishConversation()
    {
        speechBalloon.SetActive(false);
        playerSpeechBalloon.SetActive(false);
        GameObject lastJerryCanObject=Instantiate(lastJerryCan,jerryCans);
        lastJerryCanObject.transform.localPosition = new Vector3(29750f,-410f,0f);
    }
}
