using UnityEngine;

using System.Linq;
using TMPro;

public class Motor : MonoBehaviour
{
    public TextMeshPro textoNivel;
    // Array que contiene las anomalias, lee todas las anomalias de la carpeta Anomalias
    private Anomalias[] anomalias;
    private static bool[] vistas;

    // Nivel
    public static int nivel = 0;
    private bool activatedAnomaly;
    private int index;
    private static int nivelMaximo;

    private Anomalias anomalia;

    // Si anomalias esta vacia, añade las anomalias de la carpeta Anomalias
    private void Awake()
    {
        
        anomalias = GameObject.FindGameObjectsWithTag("anomalia")
            .Select(obj => obj.GetComponent<Anomalias>())
            .ToArray();

        if (vistas == null){
            vistas = new bool[anomalias.Length];
            Debug.Log("Vistas inicializadas");
        }
        activatedAnomaly = false;

        // Si no hay anomalias, mostrar mensaje de error
        if (anomalias.Length == 0)
        {
            Debug.LogError("No hay anomalias en la carpeta Anomalias");
        }

        nivelMaximo = anomalias.Length - 1;

        // Cambia el nivel a texto = B + nivel

        textoNivel.text = "B" + nivel;

        // Log numero de anomalias
        Debug.Log("Numero de anomalias: " + anomalias.Length);
    
    }

    // Al iniciar, obtiene una anomalia de anomalias, la activa y la guarda en vistas
    // No se puede repetir anomalias

    private void Start(){

        // Hace todas las anomalias no visibles
        foreach (Anomalias anly in anomalias)
        {
            anly.gameObject.SetActive(false);
        }

        // Una de cada 6 veces, no se activa ninguna anomalia
        if (Random.Range(0, 6) == 0 || nivel == 0)
        {
            return;
        }

        // Selecciona una anomalia aleatoria
        index = Random.Range(0, anomalias.Length);
        while (vistas[index])
        {
            index = Random.Range(0, anomalias.Length);
        }

        //Debug.Log("Index: "+index);
        anomalia = anomalias[index];

        // Activa la anomalia
        anomalia.Activar();

        // Indicar que se ha activado una anomalia
        activatedAnomaly = true;
    }

    public void levelUP()
    {
        // Si habia una anomalia sumar un nivel, sino bajar a 0
        if (activatedAnomaly)
        {
            vistas[index] = true;
            nivel++;
        }
        else
        {
            nivel = 0;
        }
        resetLevel();
    }


    public void levelDown()
    {
        // Si habia no hay anomalia sumar un nivel, sino bajar a 0
        if (!activatedAnomaly)
        {   
            nivel++;
        }
        else
        {
            nivel = 0;
        }

        resetLevel();

    }

    private void resetLevel()
    {
        Anomalias.idAnomalias = 0;
        // Si todas han sido vistas, volver al menu
        if (vistas.All(vista => vista))
        {
            // Borrar anomalias vistas
            vistas = null;
            Debug.Log("Vistas borradas");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        
    }



}