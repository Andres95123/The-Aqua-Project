using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingSetter : MonoBehaviour
{

    // Método Start se ejecuta una vez al inicio del juego
    void Start()
    {
        int quality = GraphicsController.qualityLevel;
        Debug.Log("Quality level: " + quality);

        // Busca todos objetos que contengan en el tag "PPV"
        GameObject[] ppvObjects = GameObject.FindGameObjectsWithTag("PPV");

        // Mira la prioridad de cada objeto y activa el que tenga la misma prioridad que la calidad
        foreach (GameObject ppvObject in ppvObjects)
        {
            PostProcessVolume ppv = ppvObject.GetComponent<PostProcessVolume>();
            if (ppv != null)
            {
                if (ppv.priority == quality)
                {
                    ppv.enabled = true;
                }
                else
                {
                    ppv.enabled = false;
                }
            }
        }

    }



}