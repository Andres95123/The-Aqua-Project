using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    static float puntuacion;

    // Texto Pro

    public TMPro.TextMeshProUGUI textoPuntuacion;

    
    // Start is called before the first frame update
    void Start()
    {

        puntuacion = 0;
        textoPuntuacion.text = "Puntuacion: " + puntuacion;
        
    }

    // addPuntuacion

    public void addPuntuacion(float puntos)
    {
        puntuacion += puntos;
        textoPuntuacion.text = "Puntuacion: " + puntuacion;
    }

    // Gett

    public float getPuntuacion()
    {
        return puntuacion;
    }
    
}
