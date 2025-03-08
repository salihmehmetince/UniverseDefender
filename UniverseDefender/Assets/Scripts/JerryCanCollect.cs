using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JerryCanCollect : MonoBehaviour
{
    private const string finalFirstJerryCan = "FirstJerryCan";
    private const string finalJerryCan = "JerryCan";

    [SerializeField]
    private TextMeshProUGUI speechBalloonText;

    [SerializeField]
    private GameObject speechBalloon;

    private List<GameObject> jerryCans = new List<GameObject>();

    [SerializeField]
    private Slider slider;

    private const string finalRocketAndPlayer = "RocketAndPlayer";

    private int maxJerryCans = 25;

    [SerializeField]
    private Animator rocketAndPlayerAnimator;

    private const string finalIsNextLevel = "IsNextLevel";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==finalFirstJerryCan)
        {
            speechBalloonText.text = "Seni küçük þey sen nerden geldin";
            speechBalloon.SetActive(true);
            Invoke(nameof(waitToCloseSpeechBalloon), 2f);
            jerryCans.Add(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == finalJerryCan)
        {
            jerryCans.Add(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag==finalRocketAndPlayer && jerryCans.Count>=maxJerryCans)
        {
            Debug.Log("oyun bitti");
            gameObject.SetActive(false);
            rocketAndPlayerAnimator.enabled = true;
            rocketAndPlayerAnimator.SetTrigger(finalIsNextLevel);
            Invoke(nameof(waitToNextLevel), 2f);
        }
        slider.value = jerryCans.Count;
    }

    private void waitToCloseSpeechBalloon()
    {
        speechBalloon.SetActive(false);
    }

    private void waitToNextLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
