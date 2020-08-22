using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public Bounds worldBounds;
    private ObjectPoolerManager objectPoolerManager;

    private List<GameObject> asteroids = new List<GameObject>();
    private List<Mesh> asteroidMeshes = new List<Mesh>();

    [Tooltip("Min Number of asteroid can be on the world at the sime time.")]
    public int minNumberOfAsteroidOnScreen = 3;

    [Tooltip("Initial scale size for the asteroid")]
    public float asteroidInitialScaleSize = 100;

    void Start()
    {
        objectPoolerManager = GameManager.Instance.objectPoolerManager;
        // Get all meshes in the resources folder, and load all of them. With this every asteroid we spawn will have a different mesh.
        // The mesh choosen is randomly selected from all the meshes loaded and set it to the new asteoid mesh.
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
        // If we have less asteroids on screen that the minimum required, let's spawn a new one!
        if (asteroids.Count < minNumberOfAsteroidOnScreen)
        {
            SpawnAnAsteroid(RandomPointInWorldBounds(), asteroidInitialScaleSize);
        }
    }

    internal void SplitAndDestroyAsteroid(Asteroid asteroid)
    {

        // Remove the asteroid from the current list and deactivate the asteroid (coming back to the pool)
        asteroids.Remove(asteroid.gameObject);
        asteroid.gameObject.SetActive(false);

        var scale = asteroid.transform.localScale;
        if (scale.x < 25f)
        {
            // Asteroid size is less than required, so we can't split more this asteroid, it's too small already!
            return;
        }
        else
        {
            // Chose a random number of asteroid to spawn
            int manyToSpawn = Random.Range(2, 3);
            for(int i = 0; i < manyToSpawn; i++)
            {
                Vector3 oldPosition = asteroid.transform.position;
                // Reduce by half the previous scale of the asteroid for the childs and spawn asteroid with the halved scale.
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

        // Get random mesh for the new asteroid from the loaded meshes found.
        Mesh asteroidMesh = asteroidMeshes[Random.Range(0, asteroidMeshes.Count)];

        // Get a new asteroid object from the pool
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

}
