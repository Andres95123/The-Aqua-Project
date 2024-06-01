using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovimientoDescendiente : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad de descenso por segundo
    private float YActual; // Altura actual del objeto
    public float Ymax = -5.8f; // Altura máxima a la que debe descender


    void Start()
    {
        YActual = transform.position.y;
        StartCoroutine(Descender());
    }

    // Usando una coroutina, cada 1s se descenderá la altura del objeto a una velocidad hasta Ymax

    private IEnumerator Descender()
    {
        while (YActual > Ymax)
        {
            YActual -= velocidad * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, YActual, transform.position.z);
            yield return new WaitForSeconds(1f);
        }
    }

    // Si colisiona con el jugador, lo lleva al menu

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    
}
