using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoBrokenSpaceshipFire : MonoBehaviour
{
    private const string finalPlayer = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == finalPlayer)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
