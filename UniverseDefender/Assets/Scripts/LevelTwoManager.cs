using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoManager : MonoBehaviour
{
    [SerializeField]
    private Animator playerAndRocketAnimator;

    [SerializeField]
    private const string finalIsReady="IsReady";

    [SerializeField]
    private GameObject playerAndRocketObject;

    private GameObject player;

    [SerializeField]
    private Transform playerObject;
    void Start()
    {
        Invoke(nameof(playerControl), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playerControl()
    {
        if (playerAndRocketAnimator.GetBool(finalIsReady))
        {
            player = playerAndRocketAnimator.transform.GetChild(0).gameObject;
            playerAndRocketAnimator.enabled = false;
            player.transform.SetParent(playerObject);
            player.transform.localPosition= new Vector3(0f,0f,0f);
            Invoke(nameof(showSpeechBallon), 1f);
            Invoke(nameof(hideSpeechBallon), 3f);
        }
    }

    private void showSpeechBallon()
    {
        player.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void hideSpeechBallon()
    {
        player.transform.GetChild(0).gameObject.SetActive(false);
    }
}
