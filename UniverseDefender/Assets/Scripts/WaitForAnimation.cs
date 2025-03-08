using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaitForAnimation : MonoBehaviour
{

    private float timer = 0f;
    private float timerMax = 4f;

    void Update()
    {
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<PlayerControler>().enabled = true;
            enabled = false;
        }
    }
}
