using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private Transform camTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get input for looking up and down
        float lookVertical = Input.GetAxis("Mouse Y");

        // Calculate movement direction based on camera's forward and right vectors
        Vector3 movement = (camTransform.forward * moveVertical + camTransform.right * moveHorizontal).normalized;
        movement.y = 0f; // Ensure no vertical movement

        // Move the player
        rb.velocity = movement * moveSpeed;

        // Rotate the camera up and down
        camTransform.Rotate(-lookVertical, 0f, 0f);

        // Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Keep the capsule upright
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
