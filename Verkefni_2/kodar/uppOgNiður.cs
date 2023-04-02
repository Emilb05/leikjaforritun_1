using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uppOgNidur : MonoBehaviour
{
    // breyta hraðanum á ferð upp og niður
    public float speed = 5f;
    // breyta hversu hátt það fer
    public float height = 1f;
void Update() 
{
        // ferð upp og niður
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed)+2, transform.position.z) * height;
}
}
