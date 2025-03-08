using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private float speed=0.5f;

    [SerializeField]
    private Renderer backgroundRenderer;

    private float timer = 0f;
    private float timerMax=4f;

    // Update is called once per frame
    void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);
            return;
        }
    }
}
