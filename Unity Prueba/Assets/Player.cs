using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal")*speed;
        float moveVertical = Input.GetAxis("Vertical")*speed;
        float jump = Input.GetAxis("Jump")*100;
        rb.AddForce(new Vector3(moveHorizontal, jump, moveVertical));

        
    }
}
