using UnityEngine;

public class Asteroid : MonoBehaviour, IPoolObject
{

    private Rigidbody rb;

    public float maxThrust;
    public float maxTorque;

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
        if (collision.transform.tag == "Bullet")
        {
            var score = Mathf.RoundToInt(transform.localScale.x);
            scoreManager.AddToScore(score);
            collision.gameObject.SetActive(false);
            worldManager.SplitAndDestroyAsteroid(this);
        }
    }

    public void OnSpawn()
    {
        rb.velocity = Vector3.zero;
        Vector3 thrust = new Vector3(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust), 0f);
        Vector3 torque = new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

}
