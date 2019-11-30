using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply movement
        SetPlayerVelocity(MovePlayer());
    }

    private void FixedUpdate()
    {
        // Check player's velocity
        if (velocity != Vector3.zero)
        {
            // Move rigid body 
            playerRB.MovePosition(playerRB.position + velocity * Time.fixedDeltaTime);
        }
    }

    void SetPlayerVelocity(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    // Handle user input and velocity calculation
    Vector3 MovePlayer()
    {
        // Calculate player movement velocity
        float movementOnX = Input.GetAxis("Horizontal");
        float movementOnZ = Input.GetAxis("Vertical");
        Vector3 movementHorizontal = transform.right * movementOnX;
        Vector3 movementVertical = transform.forward * movementOnZ;
    	// Final movement velocity vector
        Vector3 movementVelocity = (movementHorizontal + movementVertical).normalized * playerSpeed;
        
        return movementVelocity;
    }
}
