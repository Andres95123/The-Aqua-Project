using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar
    public GameObject player; // Referencia al jugador
    public SceneController sceneControll; // Referencia al controlador de escenas

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            sceneControll.ChangeScene(sceneToLoad);
        }
    }
}