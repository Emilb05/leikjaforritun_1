using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollitions : MonoBehaviour
{
    // ef 'trigger' finnur fyrir einhverju skemmast báðir hlutir
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
