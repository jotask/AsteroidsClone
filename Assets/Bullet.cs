using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{

    public Color bulletColor = Color.white;
    public float bulletSpeed = 5f;

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = bulletColor;
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

}
