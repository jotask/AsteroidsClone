﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public ObjectType type;
        public GameObject prefab;
        public int maximumObjectsAvailable;
    }
    public enum ObjectType { Bullet, Asteroid }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<ObjectType, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        // Create pool and Instantiate all pool objects and their cap limit
        poolDictionary = new Dictionary<ObjectType, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.maximumObjectsAvailable; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                obj.transform.parent = transform;
            };
            poolDictionary.Add(pool.type, objectPool);
        }
    }

    public GameObject SpawnFromPool(ObjectType type, Vector3 position, Quaternion rotation)
    {

        if (poolDictionary.ContainsKey(type) == false)
        {
            Debug.LogWarning("Pool with tag " + type.ToString() + " doesn't exist.");
            return null;
        }

        // Get the first object from the pool to spawn
        GameObject objectToSpawn = poolDictionary[type].Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        objectToSpawn.GetComponent<IPoolObject>().OnSpawn();

        // Add back the object to the back of the pool, so can be reuse if we reach pool limit.
        poolDictionary[type].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
