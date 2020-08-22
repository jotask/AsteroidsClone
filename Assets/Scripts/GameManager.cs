using UnityEngine;

public class GameManager : MonoBehaviour
{

    // We want the game manager to be a singleton as we only want one instance of this class
    public static GameManager Instance { get; private set; } = null;

    [HideInInspector] public WorldManager worldManager;
    [HideInInspector] public ScoreManager scoreManager;
    [HideInInspector] public ObjectPoolerManager objectPoolerManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Only one Game Manager instance should exist.");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        worldManager = GetComponent<WorldManager>();
        scoreManager = GetComponent<ScoreManager>();
        objectPoolerManager = GetComponent<ObjectPoolerManager>();

    }

}
