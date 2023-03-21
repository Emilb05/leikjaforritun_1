using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // hraðinn á hlutnum
    public float speed = 40.0f;
    void Update()
    {
        // hluturinn fer á 'speed' hraða. 'deltaTime' er til að hlutur hreyfist hnökralaust
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
