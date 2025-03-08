using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourTool : MonoBehaviour
{
    private const string finalPlayer="Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalPlayer)
        {
            Destroy(gameObject);
        }
    }
}
