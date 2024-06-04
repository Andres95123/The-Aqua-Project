using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    // Update is called once per frame
    void Update()
    {
        if(SceneController.primeraVez){
            Mostrar();
        }
    }

    public void Ocultar(){
        Cursor.lockState = CursorLockMode.Locked; // Volver a bloquear el cursor
        Cursor.visible = false; // Ocultar el cursor
        tutorial.SetActive(false);
        SceneController.primeraVez=false;
    }

    public void Mostrar(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        tutorial.SetActive(true);
    }

}
