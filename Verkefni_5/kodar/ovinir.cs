using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class ovinir : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;// hraðinn
    [SerializeField]
    float height = 0.5f;// hæðin

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {

        //reikna út hver nýja Y staðan er
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set hlutinn á nýja útreiknaðu Y stöðuna
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        spilari player = other.gameObject.GetComponent<spilari>();// sæki gögn frá 'spilari' skriptunni

        if (player != null)
        {
            player.ChangeHealth(-1);// breyti lífinu á spilara
        }
    }
}