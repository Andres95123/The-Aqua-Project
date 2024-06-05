using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    // Último perfil de Post Processing Volume activado
    private static PostProcessVolume lastProfile;

    // Método privado para activar un perfil específico
    private static void ActivateProfile(PostProcessVolume profile)
    {
        if (lastProfile != null)
        {
            lastProfile.enabled = false;
        }
        lastProfile = profile;
        lastProfile.enabled = true;
    }

    private void Start()
    {
        Actualizar();
    }

    public static void Actualizar()
    {
        // Obtener la cámara principal y agregarle el componente PostProcessVolume si no lo tiene
        Camera cam = Camera.main;
        if (cam != null)
        {
            PostProcessVolume postProcessVolume = cam.GetComponent<PostProcessVolume>();
            if (postProcessVolume == null)
            {
                postProcessVolume = cam.gameObject.AddComponent<PostProcessVolume>();
            }
            ActivateProfile(lastProfile); // Activar el último perfil de post-procesamiento
        }
        else
        {
            Debug.LogError("No se encontró una cámara principal en la escena.");
        }
    }
}
