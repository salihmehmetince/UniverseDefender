using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFourWarehouse : MonoBehaviour
{
    private const string finalPlayer = "Player";

    private bool hasProduct = false;

    [SerializeField]
    private GameObject productPrefab;

    private Slider transportSlider;

    private void Start()
    {
        transportSlider=transform.GetChild(1).GetComponent<Slider>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gObject = collision.gameObject;
        if(gObject.tag==finalPlayer)
        {
            if(transportSlider.value<transportSlider.maxValue)
            {
                if (!hasProduct)
                {
                    GameObject product = Instantiate(productPrefab, gObject.transform);
                    product.transform.localPosition = new Vector3(120f, 0f, 0f);
                    hasProduct = true;
                }
            }

        }
    }

    public void setHasProduct(bool hasProduct)
    {
        this.hasProduct = hasProduct;
    }

    public bool getHasProduct()
    {
        return hasProduct;
    }
}
