using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private float speed = 7f;

    private bool isWalking;

    [SerializeField]
    private GameInput gameInput;

    private const string finalEnemyBullet = "EnemyBullet";

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private RectTransform poolObject;

    private int health=5;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private GameObject gameOverSceen;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button LevelsMenuButton;

    [SerializeField]
    private Button playAgainButton;

    private const string finalIsExplode = "IsExplode";

    private void Start()
    {
        gameInput.onShoot += gameInputOnShoot;
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });

        LevelsMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LevelsScene");
        });

        playAgainButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    private void gameInputOnShoot(object sender, EventArgs e)
    {
        handleShoot();
    }

    void Update()
    {
        Vector2 inputVector = gameInput.getMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x,inputVector.y,0f);
        transform.position+=moveDirection*speed*Time.deltaTime;

        Vector2 position = new Vector2(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, 16f, 18f));
        Vector3 clampedTransform = new Vector3(position.x,position.y,0f);
        transform.position = clampedTransform;
        float degree = 0f;

        if(moveDirection.x==1 && moveDirection.y == 0)
        {
            degree =-90;
        }
        else if(moveDirection.x == -1 && moveDirection.y == 0)
        {
            degree =90;
        }
        else if (moveDirection.x == 0 && moveDirection.y == 1)
        {
            degree =0;
        }
        else if (moveDirection.x == 0 && moveDirection.y == -1)
        {
            degree =-180;
        }
        else if(moveDirection.x>0 && moveDirection.y>0)
        {
            degree = -45f;
        }
        else if(moveDirection.x < 0 && moveDirection.y > 0)
        {
            degree = 45f;
        }
        else if(moveDirection.x<0 && moveDirection.y<0)
        {
            degree = -225f;
        }
        else if(moveDirection.x > 0 && moveDirection.y < 0)
        {
            degree = 225f;
        }


        transform.GetChild(0).eulerAngles = new Vector3(0f,0f,degree);
    }

    public bool getIsWalking()
    {
        return isWalking;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == finalEnemyBullet)
        {
            Destroy(collision.gameObject);
            health--;
            healthText.text = "X " + health;
            if (health == 0)
            {
                //explode effect
                GameObject explodeObject = transform.GetChild(1).gameObject;
                GameObject explode = explodeObject.transform.GetChild(0).gameObject;
                explode.GetComponent<Animator>().SetTrigger(finalIsExplode);
                Invoke(nameof(wait), 1.5f);
            }
        }
    }

    private void handleShoot()
    {
        GameObject spaceshipBullet=Instantiate(bullet,transform.GetComponentInParent<Transform>(),false);
        spaceshipBullet.transform.SetParent(poolObject, true);
    }

    private void wait()
    {
        gameObject.SetActive(false);
        gameOverSceen.SetActive(true);
    }
}
