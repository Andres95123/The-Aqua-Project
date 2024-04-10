using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5f; // Velocidad de movimiento del personaje
    private float jumpForce = 10f; // Fuerza de salto del personaje 
    public Transform cameraTransform; // Referencia al transform de la cámara
    public GameObject ballPrefab; // Prefab de la bola roja

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleMouseInput();
        UpdateCameraPosition();
        HandleJumpInput();
        HandleShootInput();
    }

    void HandleMovementInput()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Aplicar el movimiento al personaje
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void HandleMouseInput()
    {
        // Obtener el movimiento horizontal y vertical del ratón
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotar el personaje en función del movimiento del ratón
        transform.Rotate(Vector3.up, mouseX * 30 * speed * Time.deltaTime);
        transform.Rotate(Vector3.right, mouseY * 30 * speed * Time.deltaTime);
    }

    void UpdateCameraPosition()
    {
        // Actualizar la posición de la cámara para seguir al personaje
        cameraTransform.position = transform.position;
        cameraTransform.rotation = transform.rotation;
    }

    void HandleJumpInput()
    {
        // Si se pulsa la tecla Espacio, hacer que el personaje salte
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplicar una fuerza hacia arriba al personaje para simular el salto
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleShootInput()
    {
        // Si se pulsa el botón izquierdo del ratón, disparar una bola roja
        if (Input.GetMouseButtonDown(0))
        {
            // Instanciar la bola roja en la posición y rotación del personaje
            GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            // Aplicar una fuerza hacia adelante a la bola para simular el disparo
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
