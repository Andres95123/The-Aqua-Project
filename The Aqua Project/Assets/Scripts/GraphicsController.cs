using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsController : MonoBehaviour
{
    public static int qualityLevel = 0;

    public static int LOW = 0;
    public static int MEDIUM = 1;
    public static int HIGH = 2;

    public void SetQuality(int quality)
    {
        qualityLevel = quality;
    }

    public int GetQuality()
    {
        return qualityLevel;
    }

}
