using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{

    public Color bulletColor = Color.white;
    public float bulletSpeed = 5f;

    private MeshRenderer meshRenderer;

    private WorldManager worldManager;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = bulletColor;
    }

    private void Start()
    {
        worldManager = GameManager.Instance.worldManager;
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if(worldManager.worldBounds.Contains(transform.position) == false)
        {
            Destroy(gameObject);
        }
    }

}
