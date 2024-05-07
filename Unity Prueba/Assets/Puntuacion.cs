using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public PointsController PointsController;
    // Update is called once per frame
    void Update()
    {

        // Gira el objeto alrededor del eje Y
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
        
    }

    // Se llama cuando el objeto hace trigger
    void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra en contacto es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Añade 10 puntos
            PointsController.addPuntuacion(10);
            // Destruye el objeto
            Destroy(gameObject);
        }
    }
}
