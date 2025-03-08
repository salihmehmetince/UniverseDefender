using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const string finalBullet = "Bullet";

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.up, ForceMode2D.Force);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == finalBullet)
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            //GameObject bulletExplosion = transform.GetChild();
        }
    }
}
