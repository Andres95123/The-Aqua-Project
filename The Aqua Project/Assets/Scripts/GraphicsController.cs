using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GraphicsController : MonoBehaviour
{
    public static int qualityLevel = 0;

    public static int LOW = 0;
    public static int MEDIUM = 1;
    public static int HIGH = 2;

    public void SetQuality(int quality)
    {
        qualityLevel = quality;
        Debug.Log("Calidad de gráficos cambiada a " + qualityLevel);
        // Recargar la escena para aplicar los cambios
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetQuality()
    {
        return qualityLevel;
    }

}
