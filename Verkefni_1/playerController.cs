using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// bý til opinberar breytur fyrir spilara hraðann og sigur textann.
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

	// Það er kallað á 'Start' á undan fyrsta 'frame update'
	void Start ()
	{
		// settu 'Rigidbody' íhlutnum til einka(private) 'rb' breytuna okkar
		rb = GetComponent<Rigidbody>();

		// set 'count' í núll
		count = 0;

		SetCountText ();

                // Stillir textaeiginleika af 'Win Text UI'inu í tómann streng, sem gerir „You Win“ (leik lokið skilaboðinu) autt
                winTextObject.SetActive(false);
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        
        // bætir við hreyfingu
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		// ef hluturinn sem þú snertir hefur 'tag'ið 'Pick Up' þá gerist það sem er fyrir neðan
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// bæti einum við 'count'
			count = count + 1;

			// keyrir 'SetCountText()' aðgerðina, sjá betur hér fyrir neðan
			SetCountText ();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
        // ef 'count' er 12 þá mun 'You Win' koma á skjáinn
		if (count >= 12) 
		{
                    winTextObject.SetActive(true);
		}
	}
}
