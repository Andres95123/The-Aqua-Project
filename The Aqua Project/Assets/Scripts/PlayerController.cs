using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float cameraHeight = 0.7f;
    public float maxVerticalAngle = 85f;
    public float gravityScale = 10f; // Nueva variable para ajustar la gravedad
    private Rigidbody rb;
    private Transform camTransform;
    private float pitch = 0f;
    private float yaw = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
        camTransform.position = new Vector3(transform.position.x, transform.position.y + cameraHeight, transform.position.z);
        yaw = transform.eulerAngles.y;
        pitch = camTransform.eulerAngles.x;
    }

    private void FixedUpdate()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on camera's forward and right vectors
        Vector3 movement = (camTransform.forward * moveVertical + camTransform.right * moveHorizontal).normalized;
        movement.y = 0f; // Ensure no vertical movement

        // Move the player
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // Apply custom gravity
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    private void Update()
    {
        // Get input for looking around
        float lookHorizontal = Input.GetAxis("Mouse X") * lookSpeed;
        float lookVertical = Input.GetAxis("Mouse Y") * lookSpeed;

        // Rotate the player
        yaw += lookHorizontal;
        pitch -= lookVertical;
        pitch = Mathf.Clamp(pitch, -maxVerticalAngle, maxVerticalAngle);

        transform.eulerAngles = new Vector3(0, yaw, 0);
        camTransform.eulerAngles = new Vector3(pitch, yaw, 0);

        // Update camera position
        camTransform.position = new Vector3(transform.position.x, transform.position.y + cameraHeight, transform.position.z);
    }
}
