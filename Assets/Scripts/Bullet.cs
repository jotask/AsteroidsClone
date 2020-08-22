using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{

    public float bulletSpeed = 5f;

    private WorldManager worldManager;

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

    }

}
