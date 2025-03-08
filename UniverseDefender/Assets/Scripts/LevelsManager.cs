using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{

    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private Transform parent;

    private Vector2 firstPosition = new Vector2(600,900);

    private int count = 0;

    private int distanceX = 200;

    private int distanceY = 200;

    private int row = 1;

    private int column = 3;

    private int[] storySceneNumbers = { 1,5,10,15,20};
    void Start()
    {
        
        for(int i=0;i<row;i++)
        {
            for(int j=0;j< column; j++)
            {
                Vector2 position = new Vector2(firstPosition.x+j* distanceX, firstPosition.y+(-i* distanceY));
                GameObject button=Instantiate(buttonPrefab,position,Quaternion.identity);
                button.transform.SetParent(parent);
                count++;
                button.GetComponentInChildren<Text>().text = count.ToString();
                button.GetComponent<Button>().onClick.AddListener(levelSceneLoad);
                for (int k = 0; k < storySceneNumbers.Length; k++)
                {
                    if(count== storySceneNumbers[k])
                    {
                        button.GetComponent<Button>().onClick.RemoveListener(levelSceneLoad);
                        button.GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("Level" + count + "StoryScene"); });
                        break;
                    }
                }
            }
        }

        
    }

    private void levelSceneLoad()
    {
        SceneManager.LoadScene("Level" + count+"Scene");
    }

    

}
