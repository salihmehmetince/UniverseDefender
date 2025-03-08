using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTwoStoryManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Image speechImage1;

    [SerializeField]
    private Image speechImage2;

    [SerializeField]
    private Image speechImage3;

    private const string finalIsComing = "IsComing";

    private float timer = 0f;

    private float timerMax = 1f;


    void Start()
    {
        animator.SetTrigger(finalIsComing);
        


    }

    // Update is called once per frame
    void Update()
    {
        if(timer > timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            speechImage1.gameObject.SetActive(true);
            speechImage2.gameObject.SetActive(true);
            speechImage3.gameObject.SetActive(true);
            return;
        }
    }

}
