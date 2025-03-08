using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerDown : MonoBehaviour
{
    private const string finalEnemyBullet = "EnemyBullet";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==finalEnemyBullet)
        {
            Destroy(collision.gameObject);
        }
    }
}
