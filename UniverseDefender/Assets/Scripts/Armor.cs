using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    private const string finalBullet = "Bullet";

    private const string finalIsMissileExplode = "IsMissileExplode";

    private GameObject missile;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == finalBullet)
        {
            missile = collider.gameObject;
            destroyMissile(collider.gameObject);
        }
    }

    private void destroyMissile(GameObject missile)
    {
        GameObject missileExplode = missile.transform.GetChild(1).gameObject;
        GameObject missileExplosion = missileExplode.transform.GetChild(0).gameObject;
        missileExplosion.GetComponent<Animator>().SetBool(finalIsMissileExplode, true);
        Invoke(nameof(waitToExplode), 0.2f);
    }

    private void waitToExplode()
    {
        Destroy(missile);
    }
}
