using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{

    [Tooltip("The speed the bullet will move in the space")]
    public float bulletSpeed = 5f;

    private WorldManager worldManager;

    private void Start()
    {
        worldManager = GameManager.Instance.worldManager;
    }

    void Update()
    {
        // Calculate next bullet position
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        // If the bullet is outise the world bounds, simply deactivate bullet and it's already back on the pool queue
        // Instead of doing this, we could attach a OffScreenController, so the bullet will move to the other side of the screen instead of desapearing.
        if(worldManager.worldBounds.Contains(transform.position) == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnSpawn()
    {

    }

}
