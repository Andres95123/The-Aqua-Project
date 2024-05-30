using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AscensorInteractivo : MonoBehaviour
{
    public GameObject canvas; // El canvas que contiene los botones
    public Button option1Button; // Primer botón
    public Button option2Button; // Segundo botón
    public float interactDistance = 3f; // Distancia máxima para interactuar

    private bool isCanvasActive = false;

    private void Start()
    {
        // Asegurarse de que el canvas está oculto al inicio
        canvas.SetActive(false);

        // Asignar funciones a los botones
        option1Button.onClick.AddListener(() => OnOptionSelected(1));
        option2Button.onClick.AddListener(() => OnOptionSelected(2));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isCanvasActive)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactDistance);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    if (collider.CompareTag("Player"))
                    {
                        ShowCanvas();
                        break;
                    }
                }
            }
        }
    }

    private void ShowCanvas()
    {
        canvas.SetActive(true);
        isCanvasActive = true;
        Time.timeScale = 0f; // Congelar el tiempo
        Cursor.lockState = CursorLockMode.None; // Mostrar el cursor del mouse
        Cursor.visible = true; // Hacer el cursor visible
    }

    private void OnOptionSelected(int option)
    {
        Debug.Log("Option " + option + " selected");
        canvas.SetActive(false);
        isCanvasActive = false;
        Time.timeScale = 1f; // Reanudar el tiempo
        Cursor.lockState = CursorLockMode.Locked; // Volver a bloquear el cursor
        Cursor.visible = false; // Ocultar el cursor
    }
}
