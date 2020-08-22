using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{

    public Color bulletColor = Color.white;
    public float bulletSpeed = 5f;

    private MeshRenderer meshRenderer;

    private WorldManager worldManager;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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
            gameObject.SetActive(false);
        }
    }

    public void OnSpawn()
    {
        meshRenderer.material.color = bulletColor;
    }

}
