using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();// s�ki 'Rigidbody2D'
    }

    public void Launch(Vector2 direction, float force)// sk�t hlut(byssuk�lu)
    {
        rigidbody2d.AddForce(direction * force);// b�ti vi� krafti � �tt
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)// ef �hlutur(byssuk�la) fer of langt
        {
            Destroy(gameObject);// skemmi hlut(byssuk�la)
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}