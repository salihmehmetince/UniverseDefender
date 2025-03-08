using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelTwoGameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Button playAgainButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button levelsButton;
    // Start is called before the first frame update
    void Start()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });

        levelsButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LevelsScene");
        });
    }

}
