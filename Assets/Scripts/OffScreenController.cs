using UnityEngine;

public class OffScreenController : MonoBehaviour
{

    private WorldManager worldManager;

    private void Start()
    {
        worldManager = GameManager.Instance.worldManager;
    }

    void LateUpdate()
    {

        // Lately calculate if the object attached to this script is outside of the world bounds, if it is, simply move it to the other side of the screen

        // FIXME:: This can be improved by taking into consideration the bound box of the object and take this bound box into consideration in
        // the new position calculation. With this we can fix the problem with the objects desapearing from the screen and appareing in in the
        // camera view space, by moving the spawn outside the camera view space.

        Bounds worldBounds = worldManager.worldBounds;

        if (transform.position.x > (worldBounds.size.x * 0.5f))
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
