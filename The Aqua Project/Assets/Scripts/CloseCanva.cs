using UnityEngine;

public class CloseCanva : MonoBehaviour
{

    public AscensorInteractivo ascensorInteractivo;

    void Start()
    {
    }

    void Update()
    {
        // Comprueba si se ha pulsado la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ascensorInteractivo.HideCanvas();
        }
    }
}
