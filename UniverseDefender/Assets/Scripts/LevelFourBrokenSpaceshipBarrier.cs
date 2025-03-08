using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourBrokenSpaceshipBarrier : MonoBehaviour
{
    [SerializeField]
    private GameObject emptyJerryCanPrefab;

    private float timer = 0f;

    private float timerMax = 5f;

    private void Start()
    {
        timerMax = Random.Range(4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            GameObject emptyJerryCan = Instantiate(emptyJerryCanPrefab,transform);
        }
    }
}
