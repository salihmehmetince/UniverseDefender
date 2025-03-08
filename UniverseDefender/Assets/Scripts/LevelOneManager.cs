using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private float timer = 0f;
    private float timerMax = 4f;

    [SerializeField]
    private Animator[] animators;

    private const string finalIsGo="IsGo";

    private const string finalIsMove = "IsMove";

    [SerializeField]
    private GameObject armor;

    private int spaceshipNumber = 3;

    [SerializeField]
    private GameObject badUfoSpeechBalloon;

    [SerializeField]
    private Animator badAlienAnimator;

    [SerializeField]
    private GameObject playerSpeechBalloon;

    [SerializeField]
    private Animator playerAnimator;

    private const string finalIsEscape = "IsEscape";

    private const string finalIsCatch = "IsCatch";


    void Start()
    {
        animator.SetTrigger(finalIsGo);
        LevelOneBadUfoOffensive.onUfoDestroyed += leveloneUfosDestroyed;
    }

    private void leveloneUfosDestroyed(object sender, EventArgs e)
    {
        spaceshipNumber--;
        if (spaceshipNumber <= 0)
        { 
            armor.SetActive(false);
            badUfoSpeechBalloon.SetActive(true);
            badAlienAnimator.SetTrigger(finalIsEscape);
            Invoke(nameof(playerFinishScene),4f);
            Invoke(nameof(loadNext), 8f);
        }
        
    }

    private void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            for(int i=0;i<animators.Length;i++)
            {
                animators[i].SetBool(finalIsMove,true);
            }
            animator.enabled = false;
            enabled = false;

        }

    }
    private void loadNext()
    {
        SceneManager.LoadScene("LevelsScene");
    }

    private void playerFinishScene()
    {
        playerSpeechBalloon.SetActive(true);
        playerAnimator.enabled = true;
        playerAnimator.SetTrigger(finalIsCatch);
    }

}
