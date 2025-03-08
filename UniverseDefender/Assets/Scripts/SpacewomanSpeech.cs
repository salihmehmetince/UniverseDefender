using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpacewomanSpeech : MonoBehaviour
{
    private string[] speechs = { "Let's go.", "Come on.", "We will be waiting.", "Help us." };

    private string speech;

    [SerializeField]
    private TextMeshProUGUI speechTMP;

    private float timer = 0f;

    private float timerMax = 5f;


    void Start()
    {
        speech = speechs[Random.Range(0, speechs.Length)];
        speechTMP.text = speech;
    }


    void Update()
    {
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            speech = speechs[Random.Range(0, speechs.Length)];
            speechTMP.text = speech;
        }
    }
}
