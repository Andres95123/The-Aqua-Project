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
    private Animator animator;
    private Transform camTransform;
    private float pitch = 0f;
    private float yaw = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        camTransform = Camera.main.transform;
        camTransform.position = new Vector3(transform.position.x, transform.position.y + cameraHeight, transform.position.z);
        yaw = transform.eulerAngles.y;
        pitch = camTransform.eulerAngles.x;
    }

    public void lookToObject(GameObject target)
    {
        if (target != null)
        {
            // Calcular la dirección hacia el objetivo
            Vector3 direction = (target.transform.position - transform.position).normalized;
            direction.y = 0f; // Asegurarse de que la dirección sea solo horizontal

            // Calcular la rotación necesaria para mirar al objetivo
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Aplicar la rotación al jugador
            transform.rotation = lookRotation;

            // Hacer que la cámara mire hacia el objetivo
            Vector3 cameraDirection = target.transform.position - camTransform.position;
            Quaternion cameraLookRotation = Quaternion.LookRotation(cameraDirection);
            camTransform.rotation = cameraLookRotation;

            // Ajustar los ángulos de yaw y pitch
            yaw = transform.eulerAngles.y;
            pitch = camTransform.eulerAngles.x;
        }
    }

    public bool playerIsLookingTo(GameObject target)
    {
        // Calcular la dirección hacia el objetivo
        Vector3 direction = (target.transform.position - transform.position).normalized;
        direction.y = 0f; // Asegurarse de que la dirección sea solo horizontal

        // Calcular la rotación necesaria para mirar al objetivo
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Calcular la diferencia de ángulo entre la rotación actual y la rotación necesaria
        float angleDifference = Quaternion.Angle(transform.rotation, lookRotation);

        // Si la diferencia de ángulo es menor a 1 grado, el jugador está mirando al objetivo
        return angleDifference < 90f;
    }

    public void rotateView(float angle)
    {
        // Actualizar el ángulo yaw con el valor del ángulo dado
        yaw += angle;
        
        // Aplicar la nueva rotación al jugador y la cámara
        transform.eulerAngles = new Vector3(0, yaw, 0);
        camTransform.eulerAngles = new Vector3(pitch, yaw, 0);
    }

    private void FixedUpdate()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Animacion de mover al personaje
        if(moveHorizontal!=0.0 || moveVertical!=0.0){
            animator.SetFloat("Speed",1);
        }else{
            animator.SetFloat("Speed",0);
        }

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
