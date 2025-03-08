using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFourGameOverScreen : MonoBehaviour
{
    [SerializeField]
    private Button playAgainButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button levelsButton;
    void Start()
    {
        playAgainButton.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });       
        mainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene"); });
        levelsButton.onClick.AddListener(() => { SceneManager.LoadScene("LevelsScene"); });
    }

}
