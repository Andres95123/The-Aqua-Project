using UnityEngine;

public class Anomalias : MonoBehaviour
{

    // ID de la anomalia
    public static int idAnomalias = 0;

    // ID de esta anomalia
    private int idAnomalia;
    public GameObject sustituible;

    // Al iniciar, hace visible la anomalia y oculta la sustituible (si la hay)

    private void Awake()
    {
        idAnomalia = idAnomalias;
        idAnomalias++;

    }

/* 
    DEJO ESTO COMENTADO POR SI EN UN FUTURO HACE FALTA

    public int GetId()
    {
        return idAnomalia;
    }
*/

    public void Activar()
    {
        this.gameObject.SetActive(true);
        if (sustituible != null)
        {
            sustituible.SetActive(false);
        }
        
        // Log id de la anomalia
        Debug.Log("Anomalia activada: " + idAnomalia);
    }


    
}