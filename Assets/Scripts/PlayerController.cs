using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private PlayerLocomotion inputActions;
    private Vector2 movementInput;
    private bool isShooting;

    public Bullet bulletPrefab;

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
    }

    private void Update()
    {
        if (isShooting)
        {
            if (shootTimer >= shootDelay)
            {
                var bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position + transform.forward;
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
        rb.AddRelativeForce(Vector3.forward * movementInput.y);
        rb.AddTorque(Vector3.forward * -movementInput.x);
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
