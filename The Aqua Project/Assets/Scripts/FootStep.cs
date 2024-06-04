using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array que contiene los sonidos de pasos
    public AudioSource audioSource; // Componente AudioSource para reproducir los sonidos


    // Función para ejecutar un sonido de paso
    public void Step()
    {
        // Reproducir un sonido de paso aleatorio del array
        if (audioSource != null)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[randomIndex]);
        }
    }
}
