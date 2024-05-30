using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovTib : MonoBehaviour
{
    private int contador=0;
    private void Update()
    {
        if(contador<3400){
            transform.position += Vector3.right*1*Time.deltaTime; 
            contador++;
            if(contador==3400){
                transform.RotateAround(transform.position, transform.up, 180f);
            }
        }else if(contador<6800){
            transform.position += Vector3.left*1*Time.deltaTime; 
            contador++;
        }else{
            contador=0;
            transform.RotateAround(transform.position, transform.up, 180f);
        }
    }
}
