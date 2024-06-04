using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    public GameObject final;
    public static bool acabado=false;

    void Update()
    {
        if(acabado){
            Mostrar();
        }
    }

    public void Ocultar(){
        Cursor.lockState = CursorLockMode.Locked; // Volver a bloquear el cursor
        Cursor.visible = false; // Ocultar el cursor
        final.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        acabado=false;
    }

    public void Mostrar(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        final.SetActive(true);
    }
}
