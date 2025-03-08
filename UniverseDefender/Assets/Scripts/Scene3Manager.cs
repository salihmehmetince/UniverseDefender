using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{

    [SerializeField]
    private Animator[] animators;

    private const string finalIsCome = "IsCome";
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<animators.Length;i++)
        {
            animators[i].SetTrigger(finalIsCome);
        }
    }

}
