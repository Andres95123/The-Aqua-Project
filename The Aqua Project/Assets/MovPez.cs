using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPez : MonoBehaviour
{
    private int contador=0;
    private void Update()
    {
        if(contador<6400){
            transform.position += Vector3.right*1*Time.deltaTime; 
            contador++;
            if(contador==6400){
                transform.RotateAround(transform.position, transform.up, 180f);
            }
        }else if(contador<12800){
            transform.position += Vector3.left*1*Time.deltaTime; 
            contador++;
        }else{
            contador=0;
            transform.RotateAround(transform.position, transform.up, 180f);
        }
    }
}
