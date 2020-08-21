using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public Bounds worldBounds;
    public GameObject asteroidPrefab;

    public int minNumberOfAsteroidOnScreen = 3;

    private List<GameObject> asteroids = new List<GameObject>();

    private List<Mesh> asteroidMeshes = new List<Mesh>();

    public float asteroidInitialScaleSize = 100;

    void Start()
    {
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
        Destroy(asteroid.gameObject);

        if (scale.x < 25f)
        {
            return;
        }
        else
        {
            int manyToSpawn = Random.Range(1, 4);
            for(int i = 0; i < manyToSpawn; i++)
            {
                SpawnAnAsteroid( oldPosition , scale.x * 0.5f);
            }
        }

    }

    void SpawnAnAsteroid(Vector3 asteroidPosition, float scale)
    {
        Mesh asteroidMesh = asteroidMeshes[Random.Range(0, asteroidMeshes.Count)];
        var asteroid = Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity, transform);
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
