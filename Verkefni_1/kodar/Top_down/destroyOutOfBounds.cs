using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    void Update()
    {
        // ef hlutur fer lengra en 'topBound' á z ásinum er hann skemdur
         if (transform.position.z > topBound) 
        {
            Destroy(gameObject);
        }// ef hlutur fer lengra en 'lowerBound' á z ásinum er hann skemdur
        else if (transform.position.z < lowerBound) 
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
