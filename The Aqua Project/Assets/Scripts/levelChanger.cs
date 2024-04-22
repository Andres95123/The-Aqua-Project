using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar
    public bool goUp;
    public GameObject player; // Referencia al jugador
    public SceneController sceneControll; // Referencia al controlador de escenas
    public AnomaliaController AnomaliaController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (goUp){
                AnomaliaController.nextLevel();
            } else {
                AnomaliaController.lastLevel();
            }
            
        }
    }
}