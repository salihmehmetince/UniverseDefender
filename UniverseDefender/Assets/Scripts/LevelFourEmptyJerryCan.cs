using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourEmptyJerryCan : MonoBehaviour
{
    private float timer = 0f;

    private float timerMax = 5f;

    void Update()
    {
        if(timer<timerMax)
        {
            timer+=Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
