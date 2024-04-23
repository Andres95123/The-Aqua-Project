using UnityEngine;

public class Anomalia : MonoBehaviour
{
    static int ids = 0;
    int id;

    public bool activada;

    private void Awake()
    {
        this.id = ids++;
        SetActivada(false);
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        if (GetComponent<Renderer>() != null){
            GetComponent<Renderer>().material.color = randomColor;
        }
    }

    public int GetId()
    {
        return id;
    }

    public bool GetActivada()
    {
        return activada;
    }

    public void SetActivada(bool activada)
    {
        this.activada = activada;
        this.gameObject.SetActive(activada);
    }
}