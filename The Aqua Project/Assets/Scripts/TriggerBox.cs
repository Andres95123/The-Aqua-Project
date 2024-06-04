using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Anomalias anomalia;
    public GameObject[] objetosExtra;
    public bool ocultarObjetos = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject objeto in objetosExtra)
            {
                objeto.SetActive(!ocultarObjetos);
            }

            if (anomalia != null){
                anomalia.Activar();
            }

        }
    }
}