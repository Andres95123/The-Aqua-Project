using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomaliaController : MonoBehaviour
{

    public Anomalia[] anomalias;
    int anomaliaActiva = 0;

    static int nivel = 0;

    public TMPro.TextMeshProUGUI nivelText;
    public SceneController sceneControll;


    // Start is called before the first frame update
    void Start()
    {
        RecargarAnomalia();
    }

    public void RecargarAnomalia()
    {
        anomalias[anomaliaActiva].SetActivada(false);
        if (Random.Range(0, 6) > 0)
        {
            // Una de cada 6 veces, no se activa ninguna anomalia
            anomaliaActiva = Random.Range(0, anomalias.Length);
            anomalias[anomaliaActiva].SetActivada(true);

        }

        nivelText.text = "Nivel: " + nivel;

    }

    public void nextLevel()
    {
        if (!anomalias[anomaliaActiva].GetActivada())
        {
            nivel++;

        }
        else
        {
            nivel = 0;
        }
        sceneControll.ChangeScene("Map");
    }

    public void lastLevel()
    {
        if (anomalias[anomaliaActiva].GetActivada())
        {
            nivel++;
        }
        else
        {
            nivel = 0;
        }
        sceneControll.ChangeScene("Map");
    }




    // Update is called once per frame
    void Update()
    {

    }
}
