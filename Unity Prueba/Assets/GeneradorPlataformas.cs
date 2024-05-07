using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Genera una plataforma encima de la main camara

        // Encontrar la main camara
        Camera mainCamera = Camera.main;

        // Crear plataformas encima
        for (int i = 0; i < 500; i++)
        {
            // Crear una plataforma en la posicion de la main camara + 10
            GameObject plataforma = GameObject.CreatePrimitive(PrimitiveType.Cube);
            int randomX = Random.Range(-30, 30);
            int randomZ = Random.Range(-30, 30);
            plataforma.transform.position = new Vector3(mainCamera.transform.position.x + randomX , mainCamera.transform.position.y + 10*i, mainCamera.transform.position.z + randomZ);
            plataforma.transform.localScale = new Vector3(10, 1, 10);
            plataforma.AddComponent<Rigidbody>();
            plataforma.GetComponent<Rigidbody>().useGravity = false;
            plataforma.GetComponent<Rigidbody>().isKinematic = true;
            plataforma.AddComponent<BoxCollider>();
            
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
