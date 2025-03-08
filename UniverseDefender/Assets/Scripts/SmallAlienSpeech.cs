using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmallAlienSpeech : MonoBehaviour
{

    private string[] speechs = {"Will you help us?","Let's go.", "It is cleaning time.", "Shall we send them away?" };


    private string speech;

    [SerializeField]
    private TextMeshProUGUI speechTMP;

    private float timer=0f;

    private float timerMax=5f;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        animator.SetTrigger("IsSpeech");
        speech = speechs[Random.Range(0, speechs.Length)];
        speechTMP.text = speech;
    }

    
    void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
            animator.SetTrigger("IsNotSpeech");
        }
        else
        {
            timer = 0f;
            speech = speechs[Random.Range(0, speechs.Length)];
            speechTMP.text = speech;
            animator.SetTrigger("IsSpeech");
        }
    }
}
