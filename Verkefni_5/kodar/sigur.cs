using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sigur : MonoBehaviour
{

    void Start()
    {
        Debug.Log("byrja");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")//ef 'tag'ið er það sama og 'Player'
        {
            SceneManager.LoadScene(3);//sena 3
        }
    }
}