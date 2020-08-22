using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour, IPoolObject
{

    [Header("Asteroid Settings")]
    public float maxThrust;
    public float maxTorque;

    private Rigidbody rb;
    private WorldManager worldManager;
    private ScoreManager scoreManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        worldManager = GameManager.Instance.worldManager;
        scoreManager = GameManager.Instance.scoreManager;
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Check if has been collided with a bullet.
        if (collision.transform.tag == "Bullet")
        {
            // The score is defined by the scale of the asteroid. Bigger asteroid more points.
            var score = Mathf.RoundToInt(transform.localScale.x);
            scoreManager.AddToScore(score);
            collision.gameObject.SetActive(false);
            worldManager.SplitAndDestroyAsteroid(this);
        }
    }

    public void OnSpawn()
    {
        // This asteroid has been getted from the pool, let's calculatea a random thrust and torque forces so it's moving from the beggining.
        rb.velocity = Vector3.zero;
        Vector3 thrust = new Vector3(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust), 0f);
        Vector3 torque = new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

}
