using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovTib : MonoBehaviour
{
    public float xmin = 0f;
    public float xmax = 10f;
    public float speed = 1f;

    private bool movingRight = true;
    private Transform cachedXform;

    private void Start()
    {
        cachedXform = transform;
        cachedXform.position = new Vector3(xmin, cachedXform.position.y, cachedXform.position.z);
    }

    private void Update()
    {
        float direction = movingRight ? 1f : -1f;
        cachedXform.position = new Vector3(cachedXform.position.x + direction * speed * Time.deltaTime, cachedXform.position.y, cachedXform.position.z);

        float posX = cachedXform.position.x;
        if ((movingRight && posX >= xmax) || (!movingRight && posX <= xmin))
        {
            Flip();
        }
    }

    private void Flip()
    {
        cachedXform.RotateAround(cachedXform.position, cachedXform.up, 180f);
        movingRight = !movingRight;
    }
}
