using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private ParticleSystem thrusterParticleSystem;
    private Rigidbody rb;
    private PlayerLocomotion inputActions;
    private ObjectPoolerManager objectPoolerManager;

    private Vector2 movementInput;
    private bool isShooting;
    private float shootTimer = 0f;

    [Header("SpaceShip Stats")]
    public float thrustForce = 5f;
    public float turnThrustForce = 5f;
    public float shootDelay = 1f;


    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerLocomotion();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerAction.Shot.started += inputActions => StartShooting();
            inputActions.PlayerAction.Shot.canceled += inputActions => StopShooting();
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        thrusterParticleSystem = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        objectPoolerManager = GameManager.Instance.objectPoolerManager;
    }

    private void Update()
    {
        if (isShooting)
        {
            if (shootTimer >= shootDelay)
            {
                // Nice we can shoot now, get bullet from pool, set it in front of the space ship and make the forward direction the same as the spaceship
                Vector3 position = transform.position + transform.forward * 0.5f;
                var bullet = objectPoolerManager.SpawnFromPool(ObjectPoolerManager.ObjectType.Bullet, position, Quaternion.identity);
                bullet.transform.forward = transform.forward;
                shootTimer = 0f;
            }
            else
            {
                shootTimer += Time.deltaTime;
            }
        }

        // If we are moving forward active the thruster particles
        if (movementInput.y > 0)
        {
            thrusterParticleSystem.Play();
        }
        else
        {
            thrusterParticleSystem.Stop();
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * movementInput.y * thrustForce * Time.fixedDeltaTime);
        rb.AddTorque(Vector3.forward * -movementInput.x * turnThrustForce * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }

    private void StartShooting()
    {
        isShooting = true;
        shootTimer = shootDelay;
    }

    private void StopShooting()
    {
        isShooting = false;
    }

}
