using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    public Image blackScreenImage; // La imagen negra de la UI
    public float fadeDuration = 1f; // Duración de la transición

    private void Start()
    {
        // Asegurarse de que la imagen comienza opaca
        blackScreenImage.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeToClear());
    }

    private IEnumerator FadeToClear()
    {
        float elapsedTime = 0f;

        // Gradualmente cambia la transparencia de la imagen a 0 (transparente)
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            blackScreenImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Asegúrate de que la imagen esté completamente transparente al final
        blackScreenImage.color = new Color(0, 0, 0, 0);
        blackScreenImage.gameObject.SetActive(false); // Opcional: desactivar el GameObject para optimización
    }
}
