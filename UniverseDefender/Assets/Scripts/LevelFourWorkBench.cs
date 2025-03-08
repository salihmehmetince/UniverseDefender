using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourWorkBench : MonoBehaviour
{
    [SerializeField]
    private LevelFourStoreWorker worker;

    private List<Transform> tools=new List<Transform>();

    private int length;

    // Start is called before the first frame update
    void Start()
    {
        length=transform.childCount-1;
        for(int i=0;i<length;i++)
        {
            tools.Add(transform.GetChild(i+1));
        }

        for (int i = 0; i < length; i++)
        {
            if (tools[i].gameObject.activeInHierarchy)
            {
                tools[i].GetChild(0).GetComponent<Image>().sprite = worker.getToolSprites()[i];
            }
        }

    }
}
