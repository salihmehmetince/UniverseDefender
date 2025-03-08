using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoTimer : MonoBehaviour
{
    private float timer = 180f;


    private TextMeshProUGUI timerText;

    [SerializeField]
    private GameObject controlPoints;

    [SerializeField]
    private Animator playerAnimator;

    private const string finalIsFinishLevel = "IsFinishLevel";

    [SerializeField]
    private GameObject speechBalloon;
    void Start()
    {
        timerText=transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
            int minute =(int) Mathf.Floor(timer) / 60;
            int second =(int) Mathf.Floor(timer) % 60;
            string strMinute;
            string strSecond;
            if(minute<=9)
            {
                strMinute = "0" + minute;
            }
            else
            {
                strMinute = minute.ToString();
            }

            if(second<=9)
            {
                strSecond="0" + second;
            }
            else
            {
                strSecond = second.ToString();
            }

            timerText.text=strMinute+":"+strSecond;

        }
        else
        {
            controlPoints.SetActive(false);
            timerText.text = "00:00";
            playerAnimator.SetBool(finalIsFinishLevel,true);
            string message = "Bunlari da atlattik";
            handleLevelFinishSpeech(message);
            Invoke(nameof(passToNextLevel), 3f);
            enabled = false;
        }
    }

    private void handleLevelFinishSpeech(string message)
    {
        TextMeshProUGUI speechBalloonText = speechBalloon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        speechBalloonText.text = message;
        waitForSpeech();
        Invoke(nameof(waitForSpeechEnd), 2f);
    }

    private void waitForSpeech()
    {
        speechBalloon.SetActive(true);
    }

    private void waitForSpeechEnd()
    {
        speechBalloon.SetActive(false);
    }

    private void passToNextLevel()
    {
        SceneManager.LoadScene("LevelsScene");
    }
}
