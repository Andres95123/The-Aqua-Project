using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementMenu : MonoBehaviour
{
    public Transform target; // The center point of the circle
    public float radius; // The radius of the circle
    public float speed; // The speed of camera movement

    private Vector3 offset; // The offset between the camera and the target

    private void Start()
    {
        // Calculate the initial offset
        offset = transform.position - target.position;
    }

    private void Update()
    {
        // Calculate the new position around the circle
        float angle = Time.time * speed;
        Vector3 newPosition = target.position + offset + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

        // Move the camera to the new position
        transform.position = newPosition;

        // Make the camera always look at the target
        transform.LookAt(target);

        // Rotate the camera around the target
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
    }
}
