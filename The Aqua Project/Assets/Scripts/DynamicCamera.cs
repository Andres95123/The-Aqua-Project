using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public PlayerController playerController;
    private Transform playerTransform;
    public float cameraSensitivity = 2f;
    public float cameraSmoothing = 10f;

    private Vector2 currentRotation;

    private void Start()
    {
        playerTransform = playerController.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity;

        // Apply rotation to the camera
        currentRotation.x += mouseX;

        // Smoothly rotate the camera towards the target rotation
        Quaternion targetRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraSmoothing * Time.deltaTime);

        // Set the camera position to be the same as the player position
        transform.position = playerTransform.position;
    }

}
