using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerUp : MonoBehaviour
{
    private const string finalBullet = "Bullet";

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == finalBullet)
        {
            Destroy(collider.gameObject);
        }
    }
}
