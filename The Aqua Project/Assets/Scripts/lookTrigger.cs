using UnityEngine;

public class lookTrigger : MonoBehaviour
{
    private Renderer [] myrenderer;
    private PlayerController playerController;

    public bool mostrarAlMirar = false;

    void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        if (myrenderer == null || myrenderer.Length == 0)
        {
            myrenderer = GetComponentsInChildren<Renderer>();
            Debug.Log("Se encontraron " + myrenderer.Length + " renderers");
        }

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found");
        }
    }

    void Update()
    {
        if (playerController.playerIsLookingTo(gameObject))
        {
            foreach (Renderer renderer in myrenderer)
            {
                renderer.enabled = mostrarAlMirar;
            }
        }
        else
        {
            foreach (Renderer renderer in myrenderer)
            {
                renderer.enabled = !mostrarAlMirar;
            }
        }
    }

}
