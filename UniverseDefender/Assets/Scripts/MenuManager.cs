using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button settingsButton;

    [SerializeField]
    private Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(() => { SceneManager.LoadScene("LevelsScene"); }) ;
        settingsButton.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        exitButton.onClick.AddListener(() => { Application.Quit(); });
    }

    void Update()
    {
        
    }
}
