using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrokenSpaceship : MonoBehaviour
{
    private const string finalPlayer = "Player";

    [SerializeField]
    private TextMeshProUGUI speechBalloonText;

    [SerializeField]
    private GameObject speechBalloon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==finalPlayer)
        {
            speechBalloon.SetActive(true);
            speechBalloonText.text = "Sorduðuma piþmanýn\nSanýrým birileri benden daha kötü bir gün geçirmiþ";
            Invoke(nameof(waitToCloseSpeechBalloon),2f);
        }
    }

    private void waitToCloseSpeechBalloon()
    {
        speechBalloon.SetActive(false);
    }
}
