using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class LevelOneBadUfoOffensive : MonoBehaviour
{
    private int health = 3;

    
    private float timer = 0;

    [SerializeField]
    private float timerMax;

    [SerializeField]
    private GameObject enemyBullet;

    [SerializeField]
    private RectTransform poolGameObject;

    private const string finalBullet = "Bullet";

    [SerializeField]
    private GameObject explodeGameobject;

    private const string finalIsExplode = "IsExplode";

    private const string finalIsMissileExplode = "IsMissileExplode";

    private GameObject missile;

    public static event EventHandler onUfoDestroyed;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag==finalBullet)
        {
            missile = collider.gameObject;
            destroyMissile(collider.gameObject);
            health--;
            if(health==0)
            {
                //explode effect
                GameObject explodeObject = transform.GetChild(1).gameObject;
                GameObject explode = explodeObject.transform.GetChild(0).gameObject;
                explode.GetComponent<Animator>().SetTrigger(finalIsExplode);
                Invoke(nameof(waitToDestroy), 1.5f);
                onUfoDestroyed?.Invoke(this, EventArgs.Empty);
                
            }
        }
    }

    private void Start()
    {
        enabled = false;
        Invoke(nameof(delay), 3f);
    }

    private void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            GameObject _enemyBullet=Instantiate(enemyBullet,transform,false);
            _enemyBullet.transform.SetParent(poolGameObject,true);
        }
    }

    private void delay()
    {
        enabled = true;
    }

    private void waitToDestroy()
    {
        gameObject.SetActive(false);
    }

    private void destroyMissile(GameObject missile)
    {
        GameObject missileExplode = missile.transform.GetChild(1).gameObject;
        GameObject missileExplosion = missileExplode.transform.GetChild(0).gameObject;
        missileExplosion.GetComponent<Animator>().SetBool(finalIsMissileExplode, true);
        Invoke(nameof(waitToExplode), 0.15f);
    }

    private void waitToExplode()
    {
        Destroy(missile);
    }

}
