using UnityEngine;

public class LightChanger : MonoBehaviour
{
    private Light lightComponent;
    public bool activarLuz;
    public bool epilepsia;

    private void Awake()
    {

        GameObject lightObject = GameObject.FindGameObjectWithTag("Luz");
        lightComponent = lightObject.GetComponent<Light>();
        lightComponent.color = new Color(Random.value, Random.value, Random.value);

        if (Random.Range(0, 6) <= 0)
        { 
            epilepsia = true;
        }
       
    }

    private void Update(){
 // Cambiar el color de la luz

        // Cambiar la luz a una hora específica
        if (activarLuz)
        {
            // Hora actual es mayor o igual a la hora objetivo, cambiar la luz
            lightComponent.enabled = true;
        }
        else
        {
            // Hora actual es menor que la hora objetivo, desactivar la luz
            lightComponent.enabled = false;
        }

        if (epilepsia)
        {
            // Cambiar el color de la luz a un color aleatorio
            lightComponent.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}