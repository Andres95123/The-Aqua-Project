using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EyeTracker : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the current position to the target position
            Vector3 direction = target.position - transform.position;

            

            // Rotate the object to face the target
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
