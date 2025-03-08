using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelThreeDestroyer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> passiveControlPoints;

    private GameObject activeControlPoint;

    [SerializeField]
    private GameObject healthPiece;


    [SerializeField]
    private RectTransform background;
    void Start()
    {
        activeControlPoint = passiveControlPoints[0];
        passiveControlPoints.RemoveAt(0);
        activeControlPoint.transform.localPosition = new Vector3(500f,0f,0f);
        activeControlPoint.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="ControlPoint")
        {
            collision.gameObject.SetActive(false);
            collision.transform.localPosition = new Vector3(500f,1500f,0f);
            activeControlPoint = passiveControlPoints[Random.Range(0, passiveControlPoints.Count)];
            passiveControlPoints.Add(collision.gameObject);
            activeControlPoint.transform.localPosition = new Vector3(1000f, 0f, 0f);
            activeControlPoint.SetActive(true);
            produceHealthPoint();
        }
    }

    private void produceHealthPoint()
    {
        float randomValue = Random.Range(0f, 1f);

        if((randomValue >= 0f && randomValue <= 0.25f) || (randomValue>=0.75 && randomValue<=1f))
        {
            GameObject healthPoint=Instantiate(healthPiece,background);
            healthPoint.transform.localPosition = new Vector3(-550f,Random.Range(-300f,300f),0f);
        }
    }
}
