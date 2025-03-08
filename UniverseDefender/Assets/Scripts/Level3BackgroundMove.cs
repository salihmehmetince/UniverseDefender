using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Level3BackgroundMove : MonoBehaviour
{
    private float speed = 0.1f;

    private Image backgroundMaterial;
    void Start()
    {
        backgroundMaterial = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.material.mainTextureOffset+=new Vector2(speed*Time.deltaTime,0f);
    }
}
