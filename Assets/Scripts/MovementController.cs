using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float mouseRotationSensitivity = 3f;
    [SerializeField] GameObject fpsCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Rigidbody playerRB;
    private float cameraUpDownMovementSpeed = 0f;
    private float currentCameraUpDownMovementSpeed = 0f;

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float cameraUpDownMovement = Input.GetAxis("Mouse Y") * mouseRotationSensitivity;
        // Set relevant values
        SetPlayerVelocity(MovePlayer());
        SetPlayerRotation(RotatePlayer());
        SetCameraMovement(cameraUpDownMovement);
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            // Move rigid body 
            playerRB.MovePosition(playerRB.position + velocity * Time.fixedDeltaTime);
        }
        // Rotate the rigid body
        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(rotation));

        if (fpsCamera != null)
        {
            currentCameraUpDownMovementSpeed -= cameraUpDownMovementSpeed;
            // Limit the camera movement area (to avoid looking too far up or down)
            currentCameraUpDownMovementSpeed = Mathf.Clamp(currentCameraUpDownMovementSpeed, -75, 75);
            fpsCamera.transform.localEulerAngles = new Vector3(currentCameraUpDownMovementSpeed, 0, 0);
        }
    }
    #endregion

    #region Setters

    void SetPlayerVelocity(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    void SetPlayerRotation(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }

    void SetCameraMovement(float cameraSpeed)
    {
        cameraUpDownMovementSpeed = cameraSpeed;
    }

    #endregion

    #region Player Movement

    // Handle velocity 
    Vector3 MovePlayer()
    {
        // Get the user input
        float movementOnX = Input.GetAxis("Horizontal");
        float movementOnZ = Input.GetAxis("Vertical");
        // Assign right and left movement values
        Vector3 movementHorizontal = transform.right * movementOnX;
        Vector3 movementVertical = transform.forward * movementOnZ;
        // Calculate the final movement velocity and return
        return (movementHorizontal + movementVertical).normalized * playerSpeed;
    }

    // Handle player rotation
    Vector3 RotatePlayer()
    {
        // Get the mouse position on X axis 
        float rotationOnY = Input.GetAxis("Mouse X");
        // Calculate and return value for player rotation
        return new Vector3(0, rotationOnY, 0) * mouseRotationSensitivity;
    }

    #endregion
}
