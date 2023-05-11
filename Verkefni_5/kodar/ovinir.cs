using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class ovinir : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;// hra�inn
    [SerializeField]
    float height = 0.5f;// h��in

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {

        //reikna �t hver n�ja Y sta�an er
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set hlutinn � n�ja �treikna�u Y st��una
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        spilari player = other.gameObject.GetComponent<spilari>();// s�ki g�gn fr� 'spilari' skriptunni

        if (player != null)
        {
            player.ChangeHealth(-1);// breyti l�finu � spilara
        }
    }
}