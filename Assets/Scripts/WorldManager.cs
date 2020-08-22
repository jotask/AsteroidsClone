using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public Bounds worldBounds;
    private ObjectPoolerManager objectPoolerManager;

    public int minNumberOfAsteroidOnScreen = 3;

    private List<GameObject> asteroids = new List<GameObject>();

    private List<Mesh> asteroidMeshes = new List<Mesh>();

    public float asteroidInitialScaleSize = 100;

    void Start()
    {
        objectPoolerManager = GameManager.Instance.objectPoolerManager;
        var allAsteroidMeshesLoaded = Resources.LoadAll("Rocks", typeof(Mesh));
        foreach (Object obj in allAsteroidMeshesLoaded)
        {
            if ((obj is Mesh) == false)
            {
                Debug.LogWarning("Found something that is not a mesh inside the rock mesh folder! ):");
                continue;
            }
            Mesh mesh = obj as Mesh;
            asteroidMeshes.Add(mesh);
        }
    }

    void Update()
    {
        if (asteroids.Count < minNumberOfAsteroidOnScreen)
        {
            SpawnAnAsteroid(RandomPointInWorldBounds(), asteroidInitialScaleSize);
        }
    }

    internal void SplitAndDestroyAsteroid(Asteroid asteroid)
    {
        var scale = asteroid.transform.localScale;
        Vector3 oldPosition = asteroid.transform.position;

        asteroids.Remove(asteroid.gameObject);
        asteroid.gameObject.SetActive(false);

        if (scale.x < 25f)
        {
            return;
        }
        else
        {
            int manyToSpawn = Random.Range(1, 3);
            for(int i = 0; i < manyToSpawn; i++)
            {
                SpawnAnAsteroid( oldPosition , scale.x * 0.5f);
            }
        }

    }

    void SpawnAnAsteroid(Vector3 asteroidPosition, float scale)
    {

        Vector3 spawnPosition = asteroidPosition;

        // Before we spawn anything let's check if object will collide with something, so we can adjust spawn position
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, scale);
        foreach(Collider collider in colliders)
        {
            // Let's check if the new spawn point collides with this object
            if (collider.bounds.Contains(spawnPosition))
            {
                // Get the collision direction
                Vector3 collisionDirection = (collider.transform.position - spawnPosition).normalized;
                // Get the distance from two objects
                float distance = Vector3.Distance(collider.transform.position, spawnPosition);
                // Move away from this collider
                spawnPosition += collisionDirection * distance;
            }

        }

        Mesh asteroidMesh = asteroidMeshes[Random.Range(0, asteroidMeshes.Count)];

        GameObject asteroid = objectPoolerManager.SpawnFromPool(ObjectPoolerManager.ObjectType.Asteroid, spawnPosition, Quaternion.identity);
        asteroid.GetComponent<MeshFilter>().mesh = asteroidMesh;
        asteroid.transform.localScale = Vector3.one * scale;
        asteroid.GetComponent<MeshCollider>().sharedMesh = null;
        asteroid.GetComponent<MeshCollider>().sharedMesh = asteroidMesh;
        asteroids.Add(asteroid);
    }

    public Vector3 RandomPointInWorldBounds()
    {
        return new Vector3(
            Random.Range(worldBounds.min.x, worldBounds.max.x),
            Random.Range(worldBounds.min.y, worldBounds.max.y),
            0f
        );
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(worldBounds.center, worldBounds.size);
    }

    public bool IsObjectOutOfWorldBoundsCompletly(Bounds other)
    {
        return worldBounds.Intersects(other) == false;
    }

}
