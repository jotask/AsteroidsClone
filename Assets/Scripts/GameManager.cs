using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;

    public static GameManager Instance { get { return instance; }  }

    [HideInInspector] public WorldManager worldManager;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Only one Game Manager instance should exist.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        worldManager = GetComponent<WorldManager>();

    }

}
