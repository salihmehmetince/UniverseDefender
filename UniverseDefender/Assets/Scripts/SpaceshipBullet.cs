using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBullet : MonoBehaviour
{

    private float speed = 20f;
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*speed, ForceMode2D.Force);
    }
}
