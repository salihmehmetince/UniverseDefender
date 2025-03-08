using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOneStoryManager : MonoBehaviour
{
    private enum States
    {
        SceneOne,
        SceneTwo,
        SceneThree,
        SceneFour
    }

    [SerializeField]
    private GameObject[] scenes;

    [SerializeField]
    private Button button;

    private States state;

    private void Start()
    {
        state=States.SceneOne;
        scenes[0].SetActive(true);
        button.onClick.AddListener(() =>
        {
            switch (state)
            {
                default:
                case States.SceneOne:
                    state = States.SceneTwo;
                    scenes[0].SetActive(false);
                    scenes[1].SetActive(true);
                    break;
                case States.SceneTwo:
                    state = States.SceneThree;
                    scenes[1].SetActive(false);
                    scenes[2].SetActive(true);
                    break;
                case States.SceneThree:
                    state = States.SceneFour;
                    scenes[2].SetActive(false);
                    scenes[3].SetActive(true);
                    break;
                case States.SceneFour:
                    SceneManager.LoadScene("Level1Scene");
                    break;
            }
        });
    }


}
