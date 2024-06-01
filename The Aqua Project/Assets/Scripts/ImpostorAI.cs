using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections;

public class Impostor : MonoBehaviour
{
    public float speed = 2.0f; // Velocidad del enemigo
    public AudioClip spawnSound; // Sonido al invocar al enemigo
    private Animator animator; // Animador para la animación de caminar
    private Transform player;
    private PlayerController playerController;

    private Rigidbody rb;

    void Start()
    {
        // Encontrar al jugador por tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Reproducir sonido al invocar al enemigo
        AudioSource.PlayClipAtPoint(spawnSound, transform.position);

        // Hacer que el jugador mire al enemigo
        if (player != null)
        {
            playerController.lookToObject(gameObject);
            StartCoroutine(PauseAndRotate());
        }

        // Iniciar animación de caminar
        if (animator != null)
        {
            animator.SetFloat("Speed",1);
        }
    }

    private IEnumerator PauseAndRotate()
    {
        // Pausar el tiempo
        Time.timeScale = 0f;

        // Esperar 1 segundo en tiempo real
        yield return new WaitForSecondsRealtime(1.25f);

        // Reanudar el tiempo
        Time.timeScale = 1f;

        // Rotar al jugador 180 grados
        playerController.rotateView(180f);
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Moverse hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Evitar que el enemigo se incline hacia adelante o hacia atrás
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

            // Mantener al enemigo de pie
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el enemigo ha tocado al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detener animación de caminar
            if (animator != null)
            {
                animator.SetFloat("Speed",0);
            }
            
            // Cargar la escena del menú
            SceneManager.LoadScene("Menu");
        }
    }
}
