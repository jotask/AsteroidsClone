using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditorInternal;
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

    [Header("SpaceShip Stats")]
    public float thrustForce = 5f;
    public float turnThrustForce = 5f;
    public float shootDelay = 1f;

    private float shootTimer = 0f;

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
    }

    private void FixedUpdate()
    {

        if (movementInput.y > 0)
        {
            thrusterParticleSystem.Play();
        }
        else
        {
            thrusterParticleSystem.Stop();
        }
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
