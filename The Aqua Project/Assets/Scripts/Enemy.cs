using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Camera mainCamara;
    private Transform target;
    public float moveSpeed = 5f;
    private AnomaliaController anomaliaController;

    private void Start()
    {
        // Encuentra el objeto del jugador
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamara = Camera.main;
        
        anomaliaController = GameObject.FindObjectOfType<AnomaliaController>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = -(target.position - transform.position);
            direction.Normalize();

            // Mira hacia el jugador
            transform.LookAt(target);

           
            // Si el jugador esta mirando al enemigo, el enemigo no se mueve
            if (Vector3.Dot(mainCamara.transform.forward, direction) >= .6f)
            {
                return;
            }

            // Mueve al enemigo hacia el jugador
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add your collision logic here
            anomaliaController.nextLevel();

        }
    }

}