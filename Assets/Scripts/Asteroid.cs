using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private Rigidbody rb;

    public float maxThrust;
    public float maxTorque;

    private WorldManager worldManager;

    void Start()
    {
        worldManager = GameManager.Instance.worldManager;
        rb = GetComponent<Rigidbody>();
        Vector3 thrust = new Vector3(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust), 0f);
        Vector3 torque = new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            var contactPoint = collision.GetContact(0).point;
            worldManager.SplitAndDestroyAsteroid(this);
        }
    }


}
