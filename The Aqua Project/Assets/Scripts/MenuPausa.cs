using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public static bool pausado=false;
    public GameObject MenuPausaUI;
    public GameObject CanvasAscensor;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !CanvasAscensor.activeSelf){
            if(pausado){
                Continuar();
            }else{
                Pausar();
            }
        }
    }

    public void Continuar(){
        Cursor.lockState = CursorLockMode.Locked; // Volver a bloquear el cursor
        Cursor.visible = false; // Ocultar el cursor
        MenuPausaUI.SetActive(false);
        Time.timeScale=1f;
        pausado=false;
    }

    private void Pausar(){
        Cursor.lockState = CursorLockMode.None; // Mostrar el cursor del mouse
        Cursor.visible = true; // Hacer el cursor visible
        MenuPausaUI.SetActive(true);
        Time.timeScale=0f;
        pausado=true;
    }

    public void LoadMenu(){
        Cursor.lockState = CursorLockMode.Locked; // Volver a bloquear el cursor
        Cursor.visible = false; // Ocultar el cursor
        Time.timeScale=1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
