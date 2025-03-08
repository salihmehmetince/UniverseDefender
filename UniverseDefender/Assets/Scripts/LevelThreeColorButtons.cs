using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelThreeColorButtons : MonoBehaviour
{
    private Button blueButton;
    private Button yellowButton;
    private Button redButton;
    private Button greenButton;
    private Button orangeButton;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        blueButton = transform.GetChild(0).GetComponent<Button>();
        yellowButton = transform.GetChild(1).GetComponent<Button>();
        redButton = transform.GetChild(2).GetComponent<Button>();
        greenButton = transform.GetChild(3).GetComponent<Button>();
        orangeButton = transform.GetChild(4).GetComponent<Button>();

        blueButton.onClick.AddListener(() => { player.GetComponent<Image>().color = blueButton.image.color; });
        yellowButton.onClick.AddListener(() => { player.GetComponent<Image>().color = yellowButton.image.color; });
        redButton.onClick.AddListener(() => { player.GetComponent<Image>().color = redButton.image.color; });
        greenButton.onClick.AddListener(() => { player.GetComponent<Image>().color = greenButton.image.color; });
        orangeButton.onClick.AddListener(() => { player.GetComponent<Image>().color = orangeButton.image.color; });
    }
}
