using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelThreeGameOverScreen : MonoBehaviour
{
    [SerializeField]
    private Button playAgainButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button levelsMenuButton;
    void Start()
    {
        playAgainButton.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        mainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene"); });
        levelsMenuButton.onClick.AddListener(() => { SceneManager.LoadScene("LevelsSceen"); });
    }


}
