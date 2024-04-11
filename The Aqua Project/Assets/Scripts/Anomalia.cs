using UnityEngine;

public class Anomalia : MonoBehaviour
{
    static int ids = 0;
    public int id;

    public bool activada;

    private void Awake()
    {
        this.id = ids++;
        SetActivada(false);
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = randomColor;
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
        Debug.Log("Anomalia activada: " + activada);
        this.activada = activada;
        this.gameObject.SetActive(activada);
    }
}