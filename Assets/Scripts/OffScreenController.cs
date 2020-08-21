using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OffScreenController : MonoBehaviour
{

    private WorldManager worldManager;

    private void Start()
    {
        worldManager = GameManager.Instance.worldManager;
    }

    void LateUpdate()
    {
        Bounds worldBounds = worldManager.worldBounds;
        if (transform.position.x > worldBounds.size.x * 0.5f)
        {
            transform.position = new Vector3(-worldBounds.size.x * 0.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -worldBounds.size.x * 0.5f)
        {
            transform.position = new Vector3(worldBounds.size.x * 0.5f, transform.position.y, 0);
        }

        else if (transform.position.y > worldBounds.size.y * 0.5f)
        {
            transform.position = new Vector3(transform.position.x, -worldBounds.size.y * 0.5f, 0);
        }

        else if (transform.position.y < -worldBounds.size.y * 0.5f)
        {
            transform.position = new Vector3(transform.position.x, worldBounds.size.y * 0.5f, 0);
        }
    }
}
